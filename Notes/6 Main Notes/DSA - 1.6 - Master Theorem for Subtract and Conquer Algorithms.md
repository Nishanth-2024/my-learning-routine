# Master Theorem for Subtract and Conquer Algorithms


> [!my-definition-callout] Master Theorem for Subtract and Conquer algorithms
> 
> Subtract and conquer algorithms solve problems by reducing them to *smaller* instances of the *same* problem.  Unlike divide and conquer, they typically make only *one* recursive call.  A common recurrence relation form for subtract and conquer algorithms is:
> 
> $$
> \begin{aligned}
> \text{Let } T(n) \text{ be a function defined for } n \geq 0 \text{ such that} \\
> & T(n) =
> \begin{cases}
> & c, & \text{if } n \leq 1 \\
> & aT(n-b) + f(n), & \text{if } n > 1
> \end{cases} \\
> \text{for some constants } c, a > 0, b \geq 0, k \geq 0, \text{ and function } f(n). \text{ If } f(n) \text{ is in } O(n^k), \text{ then} \\
> & T(n) =
> \begin{cases}
> & O(n^k), & \text{if } a < 1 \\
> & O(n^{k+1}), & \text{if } a = 1 \\
> & O(n^k a^{\frac{n}{b}}), & \text{if } a > 1
> \end{cases}
> \end{aligned}
> $$
> 

**Simplified Cases and Analysis:**

Because subtract and conquer algorithms often don't divide the problem into multiple parts, the Master Theorem isn't directly applicable.  We usually analyse these recurrences using other techniques like:

1. **Substitution Method:** Repeatedly substitute the recurrence into itself until a pattern emerges, which can then be proven using induction.

2. **Recursion Tree Method:** Visualise the recursive calls as a tree, where each node represents a subproblem. The total work is the sum of the work done at each level of the tree.

3. **Guess and Check:** Make an educated guess about the solution and then prove it using induction.

**Common Examples and Analysis:**

4. **Linear Search (Recursive Version):**

    * Recurrence:  *T(n) = T(n-1) + c*  (where 'c' is constant time for comparison)
    * Analysis (Substitution):
        * T(n) = T(n-1) + c
        * T(n) = (T(n-2) + c) + c = T(n-2) + 2c
        * T(n) = T(n-3) + 3c
        * ...
        * T(n) = T(1) + (n-1)c  (Base case T(1) is constant)
        * T(n) = O(n)

5. **Fibonacci Sequence (Recursive, Inefficient Version - Demonstrates Overlapping Subproblems):**

    * Recurrence: *T(n) = T(n-1) + T(n-2) + c*
    * Analysis:  While not strictly "subtract and conquer" in the purest sense (two recursive calls), it illustrates how these methods can be applied.  The recursion tree method is often useful here, showing significant redundant computations. The time complexity is exponential.

6. **Tower of Hanoi:**

    * Recurrence: *T(n) = 2T(n-1) + c* (Moving n disks involves moving n-1, then the largest, then n-1 again)
    * Analysis (Substitution):
        * T(n) = 2(T(n-1)) + c
        * T(n) = 2(2T(n-2) + c) + c = 2^2 T(n-2) + 2c + c
        * T(n) = 2^3 T(n-3) + 2^2c + 2c + c
        * ...
        * T(n) = 2^(n-1)T(1) + c(2^(n-1) + 2^(n-2) + ... + 1)
        * T(n) = O(2^n)

**Key Differences from Divide and Conquer:**

* **Number of Subproblems:** Subtract and conquer typically solves the problem by reducing it to *one* smaller subproblem, whereas divide and conquer breaks it into *multiple* subproblems.
* **Applicability of Master Theorem:** The Master Theorem is generally *not* applicable to subtract and conquer recurrences.  Different analysis techniques are required.

**When to Use Subtract and Conquer:**

Subtract and conquer is useful when the problem can be naturally reduced to a slightly smaller version of itself, and the overhead of combining results (if any) is relatively low.

<br>

---
---

> [!Info]- References & MetaData Information
> 
> Created On: 09 February 2025
> 
> Status: #baby
> 
> Keywords: #DataStructures #Algorithm #DivideAndConquer #MasterTheorem
> 
> Tags: [[4 Indexes/DSA - Narasimha Karumanchi|DSA - Narasimha Karumanchi]]

---
---

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)