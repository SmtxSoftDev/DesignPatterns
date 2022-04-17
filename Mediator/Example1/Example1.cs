namespace Mediator
{
    public abstract class Mediator
    {
        public abstract void Send(string msg, Employee employee);
    }

    public abstract class Employee
    {
        protected Mediator mediator;

        public Employee(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(string message)
        {
            mediator.Send(message, this);
        }

        public abstract void Notify(string message);
    }

    public class CustomerEmployee : Employee
    {
        public CustomerEmployee(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine($"Message for customer: {message}");
        }
    }

    public class ProgrammerEmployee : Employee
    {
        public ProgrammerEmployee(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine($"Message for programmer: {message}");
        }
    }

    public class TesterEmployee : Employee
    {
        public TesterEmployee(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine($"Message for tester: {message}");
        }
    }

    public class ManagerMediator : Mediator
    {
        public ProgrammerEmployee programmer { get; set; }
        public TesterEmployee tester { get; set; }
        public CustomerEmployee customer { get; set; }

        public override void Send(string msg, Employee employee)
        {
            if (employee is CustomerEmployee)
                programmer.Notify(msg);
            if (employee is ProgrammerEmployee)
                tester.Notify(msg);
            if (employee is TesterEmployee)
                customer.Notify(msg);
        }
    }

    public class Example1
    {
        public static void Test()
        {
            ManagerMediator manager = new();
            CustomerEmployee customer = new CustomerEmployee(manager);
            ProgrammerEmployee programmer = new ProgrammerEmployee(manager);
            TesterEmployee tester = new TesterEmployee(manager);
            manager.customer = customer;
            manager.programmer = programmer;
            manager.tester = tester;
            customer.Send("There is an order, you should make a program");
            programmer.Send("Software is ready, needed testing");
            tester.Send("Software testing is completed successfully and ready to sell");
        }
    }
}
