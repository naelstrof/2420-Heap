using System.Collections.Generic;
using System;

namespace Heaps {
    public class Heap {
        List<int> values = new List<int>();
        int heapLength = 1;
        public Heap() {
            // placeholder to simplify math.
            values.Add( 0 );
        }
        public int this[int index] {
            get { return values[index + 1]; }
        }
        public void Add( int foo ) {
            int index = heapLength;
            int preindex = index;
            values.Add( foo );
            heapLength++;
            while ( index/2 != 0 ) {
                // integer division is great for this.
                index /= 2;
                if ( values[index] >= values[preindex] ) {
                    break;
                }
                // swap
                int temp = values[index];
                values[index] = values[preindex];
                values[preindex] = temp;
                preindex /= 2;
            }
        }
        // Like Add() but does everything in-place.
        private void NoAdd( int foo ) {
            int index = heapLength-1;
            int preindex = index;
            values[ heapLength-1 ] = foo;
            heapLength++;
            while ( index/2 != 0 ) {
                // integer division is great for this.
                index /= 2;
                if ( values[index] >= values[preindex] ) {
                    break;
                }
                // swap
                int temp = values[index];
                values[index] = values[preindex];
                values[preindex] = temp;
                preindex /= 2;
            }
        }
        // Gets the max value off the heap, and does a 'fake' pop.
        // Allows for me to sort in-place without messing with list sizes.
        private int NoPop() {
            int index = 1;
            int popMem = values[index];
            while ( index*2 < heapLength ) {
                int lindex = index*2;
                int rindex = index*2+1;
                // yay for convoluted one-liners, this should actually be faster
                // than a bunch of if statements since it doesn't fork.
                // It should also never give an out of range error since OR statements
                // stop evaluating after a single true statement is found.
                index = MoveUp( rindex >= heapLength || values[lindex] > values[rindex] ? lindex : rindex );
            }
            // gotta move everything below up...
            for( int i=index;i<heapLength-1;i++ ) {
                values[i] = values[i+1];
            }
            heapLength--;
            return popMem;
        }
        // Gets the max value off the heap and pops it for realsies.
        public int Pop() {
            int index = 1;
            int popMem = values[index];
            while ( index*2 < heapLength ) {
                int lindex = index*2;
                int rindex = index*2+1;
                // yay for convoluted one-liners, this should actually be faster
                // than a bunch of if statements since it doesn't fork.
                // It should also never give an out of range error since OR statements
                // stop evaluating after a single true statement is found.
                index = MoveUp( rindex >= heapLength || values[lindex] > values[rindex] ? lindex : rindex );
            }
            values.RemoveAt( index );
            heapLength--;
            return popMem;
        }
        // Sink, Swim, MOVE UP MAGGOT
        private int MoveUp( int index ) {
            values[index/2] = values[index];
            return index;
        }
        public void Sort() {
            int index = values.Count-1;
            while ( index != 1 ) {
                values[index] = NoPop();
                index--;
            }
        }
        public void BuildHeap() {
            int index = 1;
            while ( index < values.Count ) {
                NoAdd( values[index] );
                index++;
            }
        }
    }
}
