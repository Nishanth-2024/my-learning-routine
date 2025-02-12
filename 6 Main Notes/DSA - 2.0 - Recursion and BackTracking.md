> [!my-definition-callout] Recursion
> 
> Function that calls itself is called *recursive*.
> Recursive code is usually shorter and easier to write than iterative code.
> 
> Key concepts:
> 
> 1. base cases: conditions which upon satisfaction, makes the recursive not recur further
> 2. recursive cases: conditions that are not base cases leads to the *recursive* function to call itself at least once

> [!Example]
>
> **Fibonacci** sequence 0 1 1 2 3 5 8 13 21 . . .
> 
> $$\begin{aligned}fib(n) = \begin{cases} n & \text{if } n = 0 \lor n = 1 \\ fib(n-1) + fib(n-2) & \text{if } n > 1 \end{cases}\end{aligned}$$
> 
> <br>
> 
> recursion: $fib(n) = fib(n-1) + fib(n-2)$
> base cases: $fib(n) = n \quad for \quad n = 0 \quad \& \quad n = 1$
> 
> <br>
> 

```Typescript
function fib(n) {
  return (n <= 1) ? n : (fib(n-1) + fib(n-2))
}

function factorial(n) {
  return (n <= 2) ? n : (n * fib(n-1))
}
```

> [!Example] More Examples
> 
> 1. Merge Sort
> 2. Quick Sort
> 3. Binary Search
> 4. Tree Traversal
> 5. Graph Traversals
> 6. Dynamic Programming
> 7. Divide and Conquer, Subtract and conquer
> 8. Towers of Hanoi
> 9. BackTracking Algorithms and more ...

> [!NOTE]
> #### Recursion vs Iteration
>
> | Feature           | Recursion                                                                           | Iteration                                                                        |
> | ----------------- | ----------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
> | **Mechanism**     | Function calls itself.                                                              | Loop (`for`, `while`).                                                           |
> | **Approach**      | Breaks problem into smaller, self-similar subproblems.                              | Repeats instructions until a condition is met.                                   |
> | **Code Style**    | Can be elegant for some problems.                                                   | Can be straightforward.                                                          |
> | **Memory Usage**  | *Uses call stack, thus creating memory for each recur;*potentially stack overflow_. | *Generally less memory use unless memory is explicitly created inside the loop*. |
> | **Performance**   | *Can be slower due to function call overhead*.                                      | *Generally faster*.                                                              |
> | **Readability**   | *Can be harder to understand*.                                                      | Often easier to read.                                                            |
> | **Applicability** | Natural recursive structures (e.g., trees).                                         | Repetitive tasks.                                                                |
> | **Debugging**     | *Can be challenging*.                                                               | Easier to debug.                                                                 |
> 

> [!my-definition-callout] Backtracking
> 
> Backtracking is an improvement of the brute force approach.
> It systematically searches for a solution to a problem among all available options.
> This is a form of recursion

> [!Example] Examples
> 
> - Binary Strings: generating all binary strings
> - Generating k – ary Strings
> - N-Queens Problem
> - The Knapsack Problem
> - Generalised Strings
> - Hamiltonian Cycles
> - Graph Colouring Problem

---
---

> [!Info]- References & MetaData Information
> 
> Created On: 09 February 2025
> 
> Status: #baby
> 
> Keywords: #DataStructures #Recursion #BackTracking
> 
> Tags: [[4 Indexes/DSA - Narasimha Karumanchi|DSA - Narasimha Karumanchi]]

---
---

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)