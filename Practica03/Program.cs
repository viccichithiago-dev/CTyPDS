namespace Practica03
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramAdapter.Run();
            ProgramProxy.Run();
            ProgramCommand.Run();
            ProgramComposite.Run();
            ProgramTemplateMethod.Run();
            ProgramChain.Run();
            ProgramSingleton.Run();
        }
    }
}