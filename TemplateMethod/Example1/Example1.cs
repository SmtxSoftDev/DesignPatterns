namespace TemplateMethod
{
    /// <summary>
    /// S
    /// Open Closed Principle
    /// L
    /// I
    /// D
    /// Base class for building any project.
    /// You can use ready algorithm for building project with concrete class with 
    /// extending this base class without changin method TemplateMethodStrat.
    /// But you can modify some operation in method TemplateMethodStrat with helps extending base class
    /// and write your own changes. And that's why this is closer for principal in SOLID (Open Closed Principle)
    /// </summary>
    public abstract class BuildProject
    {
        /// <summary>
        /// This is template method which contains some algorithms for start concrete build
        /// </summary>
        public void TemplateMethodStrat()
        {
            CompileCode();
            RunTest();
            Deploy();
        }

        /// <summary>
        /// Method will compile code, this method protected for modifying,
        /// because compiling algorithm can't change anybody
        /// </summary>
        private void CompileCode()
        {
            Console.WriteLine("Code is compiled...");
        }

        /// <summary>
        /// Method for running some tests after compile program
        /// how you can see you can modify this method in your subclass
        /// because you can set your own testing logic in this method, somebody use Unit testing or Integration testing
        /// </summary>
        protected virtual void RunTest()
        {
            Console.WriteLine("Test run successfully!");
        }

        /// <summary>
        /// This method should realize each class
        /// because each base class which use this base class have own deployment configuration
        /// </summary>
        protected abstract void Deploy();
    }

    /// <summary>
    /// Concrete builder class for production server
    /// </summary>
    public class BuildProductionProject : BuildProject
    {
        /// <summary>
        /// When we deploy on production server we don't use tests in production builder class
        /// </summary>
        protected override void RunTest(){}

        /// <summary>
        /// Set some configuration for deploy on production server
        /// </summary>
        protected override void Deploy()
        {
            Console.WriteLine("Deploy on production server...");
            Console.WriteLine("\n==========================\n");
        }
    }

    /// <summary>
    /// Concrete builder class for development server
    /// </summary>
    public class BuildDevelopmentProject : BuildProject
    {
        /// <summary>
        /// Set some configuration for deploy on development server
        /// </summary>
        protected override void Deploy()
        {
            Console.WriteLine("Deploy on development server...");
        }
    }

    /// <summary>
    /// Example class for test
    /// </summary>
    public class Example1
    {
        /// <summary>
        /// Start test
        /// </summary>
        public static void Test()
        {
            List<BuildProject> builder = new List<BuildProject>();
            builder.Add(new BuildProductionProject());
            builder.Add(new BuildDevelopmentProject());
            builder.ForEach(x => { x.TemplateMethodStrat(); });
        }
    }
}