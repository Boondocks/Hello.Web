namespace Hello.Web.Models
{
    using System;

    public class DefaultModel
    {
        public Guid InstanceId { get; set; }

        public EnvironmentVariable[] EnvironmentVariables { get; set; }
    }

    public class EnvironmentVariable
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}