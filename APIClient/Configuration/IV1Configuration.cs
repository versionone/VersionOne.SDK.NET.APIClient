using System;

namespace VersionOne.SDK.APIClient
{
    public interface IV1Configuration
    {
        bool EffortTracking { get; }

        TrackingLevel StoryTrackingLevel { get; }

        TrackingLevel DefectTrackingLevel { get; }

        int MaxAttachmentSize { get; }
    }

    public enum TrackingLevel
    {
        /// <summary>
        /// Track Detail Estimate and ToDo at PrimaryWorkitem level only
        /// </summary>
        On,
        /// <summary>
        /// Track Detail Estimate and ToDo at Task/Test level only
        /// </summary>
        Off,
        /// <summary>
        /// Track Detail Estimate and ToDo at both the PrimaryWorkitem and the Task/Test levels
        /// </summary>
        Mix
    }

    public enum CapacityPlanning
    {
        On,
        Off
    }
}