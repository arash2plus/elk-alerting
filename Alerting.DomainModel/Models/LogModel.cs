using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alerting.DomainModel.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    //public class InnerException
    //{
    //    public string Type { get; set; }
    //    public int HResult { get; set; }
    //    public string Message { get; set; }
    //    public string Source { get; set; }
    //    public string SocketErrorCodeMessage { get; set; }
    //    public string SocketErrorCode { get; set; } 
    //} 

    //public class ExceptionDetail
    //{
    //    public string Type { get; set; }
    //    public int HResult { get; set; }
    //    public string Message { get; set; }
    //    public string Source { get; set; }
    //    public InnerException InnerException { get; set; }
    //}

    //public class Properties
    //{
    //    public string Environment { get; set; }
    //    public ExceptionDetail ExceptionDetail { get; set; }
    //    public string SourceContext { get; set; }
    //    public string ApplicationName { get; set; }
    //    public string DebuggerAttached { get; set; }
    //}

    //public class Event
    //{
    //    public string Level { get; set; }
    //    public Properties Properties { get; set; }
    //    public string RenderedMessage { get; set; }
    //    public DateTime Timestamp { get; set; }
    //    public string MessageTemplate { get; set; }
    //   // public string Exception { get; set; }
    //}

    //public class Headers
    //{
    //    public object http_user_agent { get; set; }
    //    public string http_version { get; set; }
    //    public string request_path { get; set; }
    //    public string request_method { get; set; }
    //    public string http_host { get; set; }
    //    public object http_accept { get; set; }
    //    public string content_type { get; set; }
    //    public string content_length { get; set; }
    //}

    //public class Source
    //{ 
    //    public DateTime Timestamp { get; set; }
    //    public string Version { get; set; }
    //    public List<Event> events { get; set; }
    //    public string host { get; set; }
    //    public Headers headers { get; set; }
    //}

    //public class Root
    //{
    //    public string _index { get; set; }
    //    public string _type { get; set; }
    //    public string _id { get; set; }
    //    public string _score { get; set; }
    //    public Source _source { get; set; }
    //}

    public class Headers
    {
        public string request_path { get; set; }
        public string http_user_agent { get; set; }
        public string http_accept { get; set; }
        public string http_version { get; set; }
        public string request_method { get; set; }
        public string http_host { get; set; }
        public string content_length { get; set; }
        public string content_type { get; set; }
    }

    public class ExceptionDetail
    {
        public string Source { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public int HResult { get; set; }
    }

    public class Properties
    {
        public string SourceContext { get; set; }
        public string ApplicationName { get; set; }
        public ExceptionDetail ExceptionDetail { get; set; }
        public string Environment { get; set; }
    }

    public class Event
    {
        public Properties Properties { get; set; }
        public string Level { get; set; }
        public string RenderedMessage { get; set; }
        public string MessageTemplate { get; set; }
        public string Timestamp { get; set; }
        public string Exception { get; set; }
    }

    public class Root
    {
        public string index { get; set; }
        public string host { get; set; }
        [JsonProperty("@timestamp")]
        public string Timestamp { get; set; }
        [JsonProperty("@version")]
        public string Version { get; set; }
        public Headers headers { get; set; }
        public List<Event> events { get; set; }
    }


}
