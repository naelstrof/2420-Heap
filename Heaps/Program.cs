using System;
using System.Diagnostics;

namespace Heaps {
    class MainClass {
        public static void Main (string[] args) {
            Heap foo = new Heap();
            // testing
            Console.WriteLine( "Testing Add()" );
            Console.Write( "Add()ing 10 values..." );
            int BIG = 999999999;
            foo.Add( 47 );
            foo.Add( 52 );
            foo.Add( 31 );
            foo.Add( 68 );
            foo.Add( 74 );
            foo.Add( 10 );
            foo.Add( 89 );
            foo.Add( 34 );
            foo.Add( 23 );
            foo.Add( 95 );
            Console.WriteLine( "Done!" );
            Console.Write( "Heap looks like this: " );
            for ( int i=0;i<10;i++ ) {
                Console.Write( foo[i] + ", " );
            }
            Console.WriteLine();
            Console.WriteLine( "Testing Pop()" );
            for ( int i=0;i<10;i++ ) {
                int bar = foo.Pop();
                Debug.Assert( bar < BIG );
                BIG = bar;
                Console.WriteLine( "Popped " + bar + "!" );
            }
            Console.Write( "Add()ing 10 more values..." );
            foo.Add( 47 );
            foo.Add( 52 );
            foo.Add( 31 );
            foo.Add( 68 );
            foo.Add( 74 );
            foo.Add( 10 );
            foo.Add( 89 );
            foo.Add( 34 );
            foo.Add( 23 );
            foo.Add( 95 );
            Console.WriteLine( "Done!" );
            Console.Write( "Heap looks like this: " );
            for ( int i=0;i<10;i++ ) {
                Console.Write( foo[i] + ", " );
            }
            Console.WriteLine();
            Console.Write( "Testing Sort()..." );
            foo.Sort();
            Console.WriteLine( "Done!" );
            Console.Write( "Heap looks like this: " );
            for ( int i=0;i<10;i++ ) {
                Debug.Assert( i == 9 || foo[i] < foo[i+1] );
                Console.Write( foo[i] + ", " );
            }
            Console.WriteLine();
            Console.Write( "Testing BuildHeap()..." );
            foo.BuildHeap();
            Console.WriteLine( "Done!" );
            Console.Write( "Heap looks like this: " );
            for ( int i=0;i<10;i++ ) {
                Console.Write( foo[i] + ", " );
            }
            Console.WriteLine();
            Console.WriteLine( "Everything appears to be in order, have a nice day!" );
        }
    }
}
