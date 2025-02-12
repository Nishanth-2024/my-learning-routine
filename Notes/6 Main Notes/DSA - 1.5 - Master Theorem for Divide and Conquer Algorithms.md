# Master Theorem for Divide and Conquer Algorithms


> [!my-definition-callout] Master Theorem for Divide and Conquer algorithm
> 
> The Master Theorem for divide and conquer algorithms helps solve recurrences with recurrence relation of form below
> 
> $$T(n) = aT(\frac{n}{b}) + f(n)$$
> 
> Where:
> 
> - `a`: Number of subproblems
> - `n/b`: Size of each subproblem
> - `f(n)`: cost of dividing the sub problems and any other work done outside the recursive calls (combining results, etc.)
> 
> The theorem tells us the time complexity `T(n)`.
> 
> **Simplified Cases:**
> 
> We compare *f(n)* to *n<sup>log<sub>b</sub>a</sup>*. Let's call *n<sup>log<sub>b</sub>a</sup>* the "critical function".
> 
> **Case 1: *f(n)* is *much smaller* than the critical function:**
> 
> $$f(n) = O(n^c) \quad where \quad c < \log_b a \quad then \quad T(n) = \Theta(n^{\log_b a})$$
> 
> **Case 2: *f(n)* is *about the same size* as the critical function (with a log factor):**
> 
> $$if \quad f(n) = \Theta(n^{\log_b a} log^k n) \quad \text{for some constant} \quad k \geq 0 \quad then \quad T(n) = Θ(n^{\log_b a} \log^{k+1} n)$$
> 
> **Case 3: *f(n)* is *much larger* than the critical function:**
> 
> $$\text{If } f(n) = \Omega(n^{\log_b a + c}) \quad \text{ for some constant } c > 0, \quad \text{ AND } \quad \text{ a special *regularity condition* holds (explained below), then:} \quad T(n) = Θ(f(n))$$
> 
> **Regularity Condition (for Case 3):**
> 
> This condition is needed only when *f(n)* grows much larger compared to $n^{\log_b a}$. It basically says that the work done at each level of the recursion shouldn't increase too rapidly.  It's often true in practice.  Formally:
> 
> There must be a constant *c* < 1 such that *a f(n/b) ≤ c f(n)* for all large enough *n*.

**Examples:**

1. **Merge Sort:** *T(n) = 2T(n/2) + n*
    - *a* = 2, *b* = 2, *f(n) = n*
    - Critical function: *n<sup>log<sub>2</sub>2</sup> = n*
    - Case 2 applies (*f(n)* is about the same size).
    - *T(n) = Θ(n log n)*

2. **Binary Search:** *T(n) = T(n/2) + 1*
    - *a* = 1, *b* = 2, *f(n) = 1*
    - Critical function: *n<sup>log<sub>2</sub>1</sup> = 1*
    - Case 2 applies (*f(n)* is about the same size).
    - *T(n) = Θ(log n)*

3. *T(n) = 3T(n/4) + n*
    - *a* = 3, *b* = 4, *f(n) = n*
    - Critical function: *n<sup>log<sub>4</sub>3</sup>* (approximately *n<sup>0.79</sup>*)
    - Case 3 applies (*f(n)* is much larger). The regularity condition holds.
    - *T(n) = Θ(n)*

**Important Note:**  The Master Theorem doesn't cover every possible recurrence.  If your recurrence doesn't fit any of the cases, you'll need to use other methods (like the substitution method or recursion tree method).

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