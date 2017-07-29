namespace InvarianceTests
{
    class InvarianceExample
    {
        public static void Main(string[] args)
        {
            // Ті ж самі правила застосовуються за узагальнених делегатів.
            
            // CO variance.
            IFactory<Child> factoryChild = new FactoryChild();

            DoCovariance(factoryChild);

            // CONTRA variance.
            IReceiver<Parent> receiverParent = new ReceiverParent();

            DoContravatiance(receiverParent);
        }

        // ----------------------- CO variance --------------------------------
        // Можливість приймати замість інтерфейсу закритого базовим типом
        // інтерфейс закритий типом що його наслідує
        //
        // або проводити неявне перетворення
        // інтерфейсу закритого типом що наслідує
        // на інтерфейс закритий базовим типом
        //
        // за умови що тип параметр в інтерфейсі стоїть лише на місці
        // типу що повертається.
        public static void DoCovariance(IFactory<Parent> factoryParent)
        {
            var result = factoryParent.CreateInstance();
        }

		// ----------------------- CONTRA variance ----------------------------
		// Можливість приймати замість інтерфейсу закритого типом що наслідує
		// інтерфейс закритий базовим типом
		//
		// або проводити неявне перетворення
		// інтерфейсу закритого тбазовим типом
		// на інтерфейс закритий типом що його наслідує
		//
		// за умови що тип параметр в інтерфейсі стоїть лише на місці
		// типу що приймається.
		public static void DoContravatiance(IReceiver<Child> receiverChild)
        {
            receiverChild.Receive(new Child());
        }
	}

    /// <summary>
    /// Base type.
    /// </summary>
	public class Parent
	{

	}

    /// <summary>
    /// Child type.
    /// </summary>
	public class Child : Parent
	{

	}


    /// <summary>
    /// Covariant interface.
    /// </summary>
    public interface IFactory<out T>
    {
        T CreateInstance();
    }

    public class FactoryParent : IFactory<Parent>
    {
        public Parent CreateInstance()
        {
            return new Parent();
        }
	}

	public class FactoryChild : IFactory<Child>
	{
		public Child CreateInstance()
		{
			return new Child();
		}
	}

    /// <summary>
    /// Contravariant interface.
    /// </summary>
    public interface IReceiver<in T>
    {
        void Receive(T data);
    }

    public class ReceiverParent : IReceiver<Parent>
    {
        public void Receive(Parent data)
        {
            
        }
    }

    public class ReceiverChild : IReceiver<Child>
    {
        public void Receive(Child data)
        {
            
        }
    }
}
