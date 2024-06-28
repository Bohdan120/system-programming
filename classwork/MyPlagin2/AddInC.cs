namespace MyPlagin2
{
    public class AddInC: MarshalByRefObject
    {
        public string DoSomething(int x) => $"AddInC: {x}";
    }
}