using System;

namespace VersionOne.SDK.APIClient.Model {
    // TODO move to separate files
    public class V1Exception : ApplicationException {
        public V1Exception(string message) : base(message) {}
        public V1Exception(string message, Exception innerException) : base(message, innerException) {}
    }

    public class ConnectionException : V1Exception {
        public ConnectionException(string message) : base(message) {}
        public ConnectionException(string message, Exception inner) : base(message, inner) {}
    }

    public class OidException : V1Exception {
        public OidException(string message, string token) : this(message, token, null) {}
        public OidException(string message, string token, Exception inner) : this(message + ": " + token, inner) {}
        public OidException(string message) : base(message, null) {}
        public OidException(string message, Exception inner) : base(message, inner) {}
    }

    public class MetaException : V1Exception {
        public MetaException(string message, string token) : this(message, token, null) {}
        public MetaException(string message, string token, Exception inner) : this(message + ": " + token, inner) {}
        public MetaException(string message) : base(message, null) {}
        public MetaException(string message, Exception inner) : base(message, inner) {}
    }

    public class APIException : V1Exception {
        public APIException(string message, string token) : this(message, token, null) {}
        public APIException(string message, string token, Exception inner) : this(message + ": " + token, inner) {}
        public APIException(string message) : base(message, null) {}
        public APIException(string message, Exception inner) : base(message, inner) {}
    }

    public class SecurityException : V1Exception {
        public SecurityException(string message) : base(message) {}
        public SecurityException(string message, Exception inner) : base(message, inner) {}
    }

    public class AttachmentLengthException : V1Exception {
        public AttachmentLengthException(string message) : base(message) {}
        public AttachmentLengthException(string message, Exception inner) : base(message, inner) {}
    }
}