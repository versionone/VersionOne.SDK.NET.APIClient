using System;
using System.IO;
using System.Xml;

namespace VersionOne.SDK.APIClient
{
    public class V1Configuration : IV1Configuration
    {

        private const string EffortTrackingKey = "EffortTracking";
        private const string StoryTrackingLevelKey = "StoryTrackingLevel";
        private const string DefectTrackingLevelKey = "DefectTrackingLevel";
        private const string MaxAttachmentSizeKey = "MaximumAttachmentSize";
        private const string CapacityPlanningKey = "CapacityPlanning";

        private readonly IAPIConnector _connector;
        private readonly V1Connector _v1Connector;
        private XmlDocument doc;

        public V1Configuration(IAPIConnector connector)
        {
            if (connector == null)
                throw new ArgumentNullException("connector");
            
            _connector = connector;
        }

        public V1Configuration(V1Connector v1Connector)
        {
            if (v1Connector == null)
                throw new ArgumentNullException("v1Connector");
            _v1Connector = v1Connector;
        }

        public bool EffortTracking
        {
            get
            {
                var value = GetSetting(EffortTrackingKey);
                return bool.Parse(value);
            }
        }

        public TrackingLevel StoryTrackingLevel
        {
            get
            {
                var result = new TrackingLevel();
                var value = GetSetting(StoryTrackingLevelKey);

                if (!string.IsNullOrEmpty(value))
                {
                    result = (TrackingLevel)Enum.Parse(typeof(TrackingLevel), value);
                }

                return result;
            }
        }

        public TrackingLevel DefectTrackingLevel
        {
            get
            {
                var result = new TrackingLevel();
                var value = GetSetting(DefectTrackingLevelKey);

                if (!string.IsNullOrEmpty(value))
                {
                    result = (TrackingLevel)Enum.Parse(typeof(TrackingLevel), value);
                }

                return result;
            }
        }

        public int MaxAttachmentSize
        {
            get
            {
                var value = GetSetting(MaxAttachmentSizeKey);
                var size = int.MaxValue;

                if (!string.IsNullOrEmpty(value))
                {
                    if (!int.TryParse(value, out size))
                    {
                        size = int.MaxValue;
                    }
                }

                return size;
            }
        }

        public CapacityPlanning CapacityPlanning
        {
            get
            {
                var result = CapacityPlanning.Off;

                var value = GetSetting(CapacityPlanningKey);
                if (!string.IsNullOrEmpty(value))
                {
                    result = (CapacityPlanning)Enum.Parse(typeof(CapacityPlanning), value);
                }

                return result;
            }
        }

        private XmlDocument Doc
        {
            get
            {
                if (doc == null)
                {
                    doc = new XmlDocument();
                    Stream stream;
                    if (_connector != null)
                    {
                        stream = _connector.GetData();
                    }
                    else
                    {
                        _v1Connector.UseConfigApi();
                        stream = _v1Connector.GetData();
                    }

                    doc.Load(stream);
                    stream.Dispose();
                }

                return doc;
            }
        }

        private string GetSetting(string keyToFind)
        {
            var configNode = Doc.SelectSingleNode("//Configuration");

            foreach (XmlNode childNode in configNode.ChildNodes)
            {
                if (childNode.Name == "Setting")
                {
                    var key = childNode.Attributes["key"].Value;
                    var value = childNode.Attributes["value"].Value;

                    if (key == keyToFind)
                    {
                        return value;
                    }
                }
            }

            return null;
        }
    }
}