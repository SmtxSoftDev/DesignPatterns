namespace TemplateMethod
{
    /// <summary>
    /// S
    /// Open closed principle
    /// L
    /// I
    /// D
    /// Base class for help start concrete job after extending by subclass.
    /// And here you can see how does is working one of the principle in SOLID (Open Closed Principle)
    /// </summary>
    public abstract class JobStarter
    {
        /// <summary>
        /// Contains time of start a job, default time 10.00
        /// </summary>
        public virtual string startTimeValue { get; set; } = "10.00";

        /// <summary>
        /// This is template method which contains some algorithms for start concrete job
        /// and don't change it!!!
        /// </summary>
        public void TemplateMethodStart()
        {
            Config config = ConfigurationData();
            StartTime(config);
            ReadDataFromConfig(config);
            PostMessage();
            MakeBrakeLine();
        }

        /// <summary>
        /// Method which must realize each sub class for set own configuration parameters
        /// </summary>
        /// <returns></returns>
        protected abstract Config ConfigurationData();

        /// <summary>
        /// Method contains template of text for show when started a job. 
        /// Method only shows start time of concrete job and
        /// subclasses doesn't have access on this method but there are can set own start of job time
        /// </summary>
        /// <param name="config"></param>
        private void StartTime(Config config)
        {
            Console.WriteLine($"Job is starting for {config.Key} in {startTimeValue}");
        }

        /// <summary>
        /// Method can send report of starting information about concrete job,
        /// defaultly method send report on Email, but you can change channel Email on any other channel which you want
        /// </summary>
        public virtual void PostMessage()
        {
            Console.WriteLine($"Post job starting information by Email!");
        }

        /// <summary>
        /// Method drawing separators after each job
        /// also you can simply reuse this method on subclass and draw your own separator
        /// </summary>
        public virtual void MakeBrakeLine()
        {
            Console.WriteLine("\n============================================\n");
        }

        /// <summary>
        /// Method read information about configuration.
        /// Method used only in base class, and subclasses doesn't have access on this method
        /// </summary>
        /// <param name="config">Configuration data</param>
        /// <exception cref="NotImplementedException"></exception>
        private void ReadDataFromConfig(Config config)
        {
            if (config?.Value == "" || config?.Key == "")
                throw new NotImplementedException("Not implementet Configurations!");

            Console.WriteLine($"Key: {config?.Key} Value: {config?.Value}");
        }

        /// <summary>
        /// Simple configuration class
        /// </summary>
        public class Config
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
    }

    /// <summary>
    /// Concrete subclass which use base class JobStarter for start automatically job for time check
    /// </summary>
    public class JobRunnerCheckTime : JobStarter
    {
        /// <summary>
        /// Realization method from base class, and write configuration parameters
        /// </summary>
        /// <returns></returns>
        protected override Config ConfigurationData()
        {
            return new Config { Key = "JobRunnerCheckTime", Value = "Start starting..." };
        }

        /// <summary>
        /// Here we are must change report channel on our own channel
        /// we need get information about running job by SMS
        /// </summary>
        public override void PostMessage()
        {
            Console.WriteLine("Post job starting information by Sms");
        }
    }

    /// <summary>
    /// Concrete subclass which use base class JobStarter for start automatically job for get information about some product
    /// </summary>
    public class JobRunnerCheckProducts : JobStarter
    {
        /// <summary>
        /// We must change start of job time to another time which we want, default time was 10.00 we change it to 11.00
        /// </summary>
        public override string startTimeValue { get; set; } = "11.00";

        /// <summary>
        /// Realization method from base class, and write configuration parameters
        /// </summary>
        /// <returns></returns>
        protected override Config ConfigurationData()
        {
            return new Config { Key = "JobRunnerCheckProducts", Value = "Start starting..." };
        }
    }

    /// <summary>
    /// Example class for test
    /// </summary>
    public class Example2
    {
        /// <summary>
        /// Start test
        /// </summary>
        public static void Test()
        {
            List<JobStarter> job = new List<JobStarter>();
            job.Add(new JobRunnerCheckTime());
            job.Add(new JobRunnerCheckProducts());
            job.ForEach(x => { x.TemplateMethodStart(); });
        }
    }
}