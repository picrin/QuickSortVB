' I created for you 3 stubs of functions/subroutines in the module below. 
' 
' You have to implement each of them, and when you implement them all you will have
' achieved a working implemention of Selection Sort.
' 
' Each of your functions will be tested against a small subtest of possible inputs.
' This technique is known in Software Engineering as "Unit Testing". Unit Testing is as
' fundamental in Software Development, as the concept of the "invariant" in Algorithms
' and Data Structures. Your implementation should pass all the Unit Tests, and be otherwise
' correct.
' 
' After you've finished the implementation, close your computer and write down on a piece
' of paper a few keywords that will make it possible for you to recall this algorithm
' through reasoning rather than memorisation.  

Imports System
Imports System.Collections

Public Module SelectionSort

  ' "elements" is the array you will be working on. You should assume values stored in it
  ' are in arbitrary order, but are comparable
  Dim elements as new ArrayList
  
  ' This subroutine should swap the value stored at the i-th index of "elements" with the value
  ' stored at the j-th index. You'll need to declare a temporary variable to execute the
  ' swap, but please do it INSIDE the function, so as not to pollute the module namespace.
  Sub swap(ByVal i as Integer, ByVal j as Integer)
    Dim t as Integer = elements(i)
    elements(i) = elements(j)
    elements(j) = t  
    '
    ' your code goes here
    '
  end Sub

  ' This function should find the index of the smallest element of "elements".
  ' Instead of looking at all possible indices, you should only consider indices between
  ' leftmost and rightmost. It will help you to try to recall the thought process that was
  ' involved in the design of pseudocode we did yesterday.
  Function minIndex(ByVal leftmost as Integer, ByVal rightmost as Integer) as Integer
    Dim index as Integer
    Dim currentMinIndex as Integer
    currentMinIndex = leftmost
    For index = leftmost to rightmost
      if elements(currentMinIndex) > elements(index)
        currentMinIndex = index
      end if
    Next
    return currentMinIndex
    '
    ' your code goes here
    '
  end Function

  ' This is the final bit -- Selection Sort. To implement this you will have to use both 
  ' functions swap and minIndex. Do not try to overcomplicate this sub, you shouldn't need
  ' more than one loop for a correct solution. It is OK if you don't manage to come up with the 
  ' implementation during the class, but try to think about it as part of your homework.
  Sub selectionSort()
    Dim index as Integer
    For index = 0 to elements.Count() - 1
      Dim nextSmallest as Integer = minIndex(index, elements.Count() - 1)
      swap(index, nextSmallest)
    Next
    '
    ' your code goes here
    '
  end Sub

  ' All functions below are there to test your program. You don't have to read them,
  ' (unless you want to have a laugh at my emarassingly poor knowledge of VB), and
  ' you shouldn't modify them.
  Sub testSwapTwo()
    elements = new ArrayList(new Integer() {1, 2, 3})
    swap(2, 1)
    if elements(1) <> 3 or elements(2) <> 2
      arrayAssertionError("swap", new Integer() {1, 3, 2} )
    end if
  end Sub

  Sub testSwapOther()
    elements = new ArrayList(new Integer() {5, 6, 2, 3})
    swap(2, 1)
    if elements(0) <> 5 or elements(3) <> 3
      arrayAssertionError("swap", new Integer() {5, 2, 6, 3})
    end if
  end Sub

  Sub testMinWholeRange()
    elements = new ArrayList(new Integer() {3, 2, 8, 0, 1, 4})
    Dim result as Integer = minIndex(0, elements.Count() - 1)
    if result <> 3
      intAssertionError("minIndex", result, 3)
    end if
  end Sub

  Sub testMinIsNarrow()
    elements = new ArrayList(new Integer() {3, 2, 8, 0, 1, 4})
    Dim result as Integer = minIndex(1, 2)
    if result <> 1
      intAssertionError("minIndex", result, 1)
    end if
  end Sub

  Sub testMinPure()
    elements = new ArrayList(new Integer() {5, 6, 2, 3})
    minIndex(0, 3)
    if elements(0) <> 5 or elements(1) <> 6 or elements(2) <> 2 or elements(3) <> 3
      arrayAssertionError("minIndex", new Integer() {5, 2, 6, 3})
    end if 
  end Sub

  Sub testSorted()
    elements = new ArrayList(new Integer() {3, 1, 2, 0})
    selectionSort()
    if elements(0) <> 0 or elements(1) <> 1 or elements(2) <> 2 or elements(3) <> 3
      arrayAssertionError("selectionSort", new Integer() {0, 1, 2, 3})
    end if
  end Sub
  
  Sub arrayAssertionError(ByVal testedFunctionName as String, expected as Integer())
     Console.Write("Error in the implementation of the ")
     Console.Write(testedFunctionName)
     Console.Write(" function. Elements should be " )
     printElements(new ArrayList(expected))
     Console.Write("but are " )
     printElements(elements)
     Console.WriteLine("") 
  end Sub
  
  Sub intAssertionError(ByVal testedFunctionName as String, actual as Integer, expected as Integer)
     Console.Write("Error in the implementation of the ")
     Console.Write(testedFunctionName)
     Console.Write(" function. I expected " )
     Console.Write(expected)
     Console.Write(" but I got " )
     Console.Write(actual)
     Console.WriteLine("")
  end Sub

  Sub printElements(ByVal elems as Object )
    Dim index as Integer = 0
    Console.Write("{")
    For index = 0 To elems.Count - 2
      Console.Write(elems(index))
      Console.Write(", ")
    Next
    Console.Write(elems(elems.Count - 1))
    Console.Write("} ")
    'Console.WriteLine("") 
  end Sub

  Sub Main()
    testSorted()
    testMinPure()
    testMinWholeRange()
    testMinIsNarrow()
    testSwapTwo()
    testSwapOther()
  end Sub

end Module
