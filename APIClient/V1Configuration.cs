using System;
using System.Xml;

namespace VersionOne.SDK.APIClient {
    public class V1Configuration : IV1Configuration {
        private readonly IAPIConnector connector;

        public V1Configuration(IAPIConnector connector) {
            this.connector = connector;
        }

        public bool EffortTracking {
            get {
                var value = GetSetting("EffortTracking");
                return bool.Parse(value);
            }
        }

        private string GetSetting(string keyToFind) {
            var configNode = Doc.SelectSingleNode("//Configuration");

            foreach (XmlNode childNode in configNode.ChildNodes) {
                if (childNode.Name == "Setting") {
                    var key = childNode.Attributes["key"].Value;
                    var value = childNode.Attributes["value"].Value;

                    if(key == keyToFind) {
                        return value;
                    }
                }
            }

            return null;
        }

        private XmlDocument doc;

        private XmlDocument Doc {
            get {
                if (doc == null) {
                    doc = new XmlDocument();

                    using(var stream = connector.GetData()) {
                        doc.Load(stream);
                    }
                }

                return doc;
            }
        }

        public TrackingLevel StoryTrackingLevel {
            get {
                var result = new TrackingLevel();
                var value = GetSetting("StoryTrackingLevel");

                if (!string.IsNullOrEmpty(value)) {
                    result = (TrackingLevel) Enum.Parse(typeof (TrackingLevel), value);
                }

                return result;
            }
        }

        public TrackingLevel DefectTrackingLevel {
            get {
                var result = new TrackingLevel();
                var value = GetSetting("DefectTrackingLevel");

                if (!string.IsNullOrEmpty(value)) {
                    result = (TrackingLevel) Enum.Parse(typeof (TrackingLevel), value);
                }

                return result;
            }
        }

        public int MaxAttachmentSize {
            get {
                var value = GetSetting("MaximumAttachmentSize");
                var size = int.MaxValue;

                if(!string.IsNullOrEmpty(value)) {
                    if (!int.TryParse(value, out size)) {
                        size = int.MaxValue;
                    }
                }

                return size;
            }
        }
    }
}