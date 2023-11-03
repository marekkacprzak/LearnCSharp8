using System.Threading.Tasks;
using Learn80.DefaultInterfaceMethods;
using Learn80.PatternMatchingEnhancements;
using Learn80.UsingDeclarations;
using Learn80.StaticLocalFunctions;
using Learn80.DisposableRefStructs;
using Learn80.NullableReferenceTypes;
using Learn80.AsynchronousStreams;
using Learn80.AsynchronousDisposable;
using Learn80.IndicesAndRanges;
using Learn80.Null_coalescingAssignment;
using Learn80.UnmanagedConstructedTypes;
using Learn80.StackallocInNestedExpressions;
using static System.Console;

public static class StartPoint
{
    public static async Task Main()
    {
        WriteLine("2.DefaultInterfaceMethods");
        DefaultInterfaceMethods.Test();
        
        WriteLine("3.PatternMatching");
        SwitchExpressions.Test();
        PropertyPatterns.Test();
        TuplePatterns.Test();
        PositionalPatterns.Test();
        
        WriteLine("4.UsingDeclarations");
        UsingDeclarations.Test();
        
        WriteLine("5.StaticLocalFunctions");
        StaticLocalFunctions.Test();
        
        WriteLine("6.DisposableRefStructs");
        DisposableRefStructs.Test();
        
        WriteLine("7.NullableReferenceTypes");
        NullableReferenceTypes.Test();
        
        WriteLine("8.AsynchronousStreams");
        await AsynchronousStreams.Test();
        
        WriteLine("9.AsynchronousDisposable");
        AsynchronousDisposable.Test();
        
        WriteLine("10.IndexAndRanges");
        IndexAndRanges.Test();
        
        WriteLine("11.Null_coalescingAssignment");
        Null_coalescingAssignment.Test();
        
        WriteLine("12.UnmanagedConstructedTypes");
        UnmanagedConstructedTypes.Test();
        
        WriteLine("13.StackallocInNestedExpressions");
        StackallocInNestedExpressions.Test();
        
        await Task.FromResult(0);
    }
}
  

