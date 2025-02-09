# Asymptotic Notation

> [!my-custom-callout-one] Table of Contents:
> 
> - Asymptotic Notation
> 	- Big O
> 	- Omega - Q
> 	- Theta - $\Theta$
> - Properties Of Asymptotic Notation

---

> [!my-definition-callout] Asymptotic Notation
> A powerful tool to analyse efficiency of an algorithm or a data-structure focusing on how it scales with larger inputs.
> 
> Types of Asymptotic Notations:
>
> - Big - O
> - Omega - Q
> - Theta
>

---

> [!my-definition-callout] Big - O Notation
>
> - describes *Upper bound* of an algorithm's *worst time complexity*
> - provides guarantee of *maximum* time required for algorithm to complete execution
> - formally, `O(g(n)) = {f(n): there exist positive constants c and n0 such that 0 ≤ f(n) ≤ cg(n) for all n > n0}. g(n) is an asymptotic tight upper bound for f(n)`.
>
> $$\begin{equation}O(g(n)) = \{ \, f(n) \, \mid \quad \exists \quad c > 0, \quad n_0 > 0, \quad \forall \quad n > n_0, \quad 0 \leq f(n) \leq cg(n) \quad \}\end{equation}$$
>
> > [!Example] Examples
> >
> > ***Example 1:*** $f(n) = 3n + 8$
> > $$\begin{equation}0 \leq 3n + 8 \leq 4n \quad \forall \quad n \geq 8\end{equation}$$
> > $$\begin{equation}f(n) = 3n + 8 = O(n) \quad with \quad c = 4 \quad and \quad n_0 = 8\end{equation}$$
> >
> > ---
> >
> > ***Example 2:***    $f(n) = n^2 + 1$
> > $$\begin{equation}0 \leq n^2 + 1 \leq 2n^2 \quad \forall \quad n \geq 1\end{equation}$$
> > $$\begin{equation}f(n) = n^2 + 1 = O(n^2) \quad with \quad c = 2 \quad and \quad n_0 = 1\end{equation}$$

---

> [!my-definition-callout] Omega - Q Notation
>
> - describes the *Lower bound* of an algorithm's *best-case time complexity*
> - provides a guarantee of the *minimum* time required for the algorithm to complete execution
> - formally, `O(g(n)) = {f(n): there exist positive constants c and n0 such that 0 ≤ cg(n) ≤ f(n) for all n > n0}. g(n) is an asymptotic tight lower bound for f(n)`.
>
> $$\begin{equation}\Omega(g(n)) = \{ \, f(n) \, \mid \quad \exists \quad c > 0,\quad  n_0 > 0, \quad \forall \quad n > n_0, \quad  0 \leq cg(n) \leq f(n) \quad \}\end{equation}$$
> 
> > [!Example] Examples
> >
> > ***Example 1:***    $f(n) = 3n + 8$
> > $$\begin{equation}0 \leq 3n \leq 3n + 8 \quad \forall \quad n \geq 1 \end{equation}$$
> > $$\begin{equation}f(n) = 3n + 8 = \Omega(n) \quad with \quad c = 3 \quad and \quad n_0 = 1\end{equation}$$
> >
> > ***Example 2:***    $f(n) = n^2 + 1$
> > $$\begin{equation}0 \leq n^2 \leq n^2 + 1 \quad \forall \quad n \geq 1\end{equation}$$
> > $$\begin{equation}f(n) = n^2 + 1 = \Omega(n^2) \quad with \quad c = 1 \quad and \quad n_0 = 1\end{equation}$$

---

> [!my-definition-callout] Theta - $\Theta$:
>
> - describes both the *Upper and Lower bounds* of an algorithm's time complexity
> - provides a guarantee of exact asymptotic behaviour, indicating that \(f(n)\) is sandwiched between two functions proportional to \(g(n)\)
> - formally, `O(g(n)) = {f(n): there exist positive constants c1, c2 and n0 such that 0 ≤ c1g(n) ≤ f(n) ≤ cg(n) for all n > n0}. g(n) is an asymptotic tight bound for f(n)`.
>
> $$\begin{equation}\Theta(g(n)) = \{ \, f(n) \, \mid \quad \exists \quad c_1 > 0, \quad c_2 > 0, \quad n_0 > 0, \quad \forall \quad n > n_0, \quad 0 \leq c_1g(n) \leq f(n) \leq c_2g(n) \quad \}\end{equation}$$
> 
> > [!Example] Examples
> >
> > ***Example 1:***    $f(n) = 3n + 8$
> >
> > $$\begin{equation}0 \leq 3n \leq 3n + 8 \leq 4n \quad \forall \quad n \geq 8 \end{equation}$$
> > $$\begin{equation}f(n) = 3n + 8 = \Theta(n) \quad with \quad c_1 = 3, \quad c_2 = 4, \quad and \quad n_0 = 8\end{equation}$$
> >
> > ---
> >
> > ***Example 2:***    $f(n) = n^2 + 1$
> >
> > $$\begin{equation}0 \leq n^2 \leq n^2 + 1 \leq 2n^2 \quad \forall \quad n \geq 1\end{equation}$$
> > $$\begin{equation}f(n) = n^2 + 1 = \Theta(n^2) \quad with \quad c_1 = 1, \quad c_2 = 2\quad and \quad n_0 = 1\end{equation}$$

---

> [!Attention] Properties of Asymptotic Notations:
>
> - Reflexivity
> - Symmetry
> - Transitivity
> - Transpose Symmetry
> - Addition
> - Multiplication
> 
> > [!content]
> >
> > **Reflexivity:**
> > A function is always bounded by itself
> >
> > $$f(n) = O(f(n))$$
> > $$f(n) = \Omega(f(n))$$
> > $$f(n) = \Theta(f(n))$$
> 
> > [!content]
> > **Symmetry:**
> > if `f` grows at the same rate as `g` in $\Theta$, `g` grows at the same rate as `f` in $\Theta$
> > > ***Note:*** Applies to Only $\Theta$ but not O and $\Omega$
> >
> > $$if \quad f(n) = \Theta(g(n)), \quad then \quad g(n) = \Theta(f(n))$$
> 
> > [!content]
> > **Transitivity:**
> > if `f` grows no faster than `g` and `g` grows no faster than `h`, then `f` also grows no faster than `h`
> >
> > $$if \quad f(n) = O(g(n)) \quad and \quad g(n) = O(h(n)) \quad then \quad f(n) = O(h(n))$$
> > $$if \quad f(n) = \Omega(g(n)) \quad and \quad g(n) = \Omega(h(n)) \quad then \quad f(n) = \Omega(h(n))$$
> > $$if \quad f(n) = \Theta(g(n)) \quad and \quad g(n) = \Theta(h(n)) \quad then \quad f(n) = \Theta(h(n))$$
> 
> > [!content]
> > **Transpose Symmetry:**
> > if `f` grows no faster than `g`, `g` grows at at least as fast as `f`
> > $$if \quad f(n) = O(g(n)) \quad then \quad g(n) = \Omega(f(n))$$
> 
> > [!content]
> > **Addition:**
> > $$if \quad f(n) = f_1(n) + f_2(n) \quad with \quad f_1(n)) = O(g_1(n)) \quad and \quad f_2(n)) = O(g_2(n)) \quad then \quad f(n) = O(\max(g_1(n), \quad g_2(n)))$$
> 
> > [!content]
> > **Multiplication:**
> > $$if \quad f(n) = f_1(n) * f_2(n) \quad with \quad f_1(n)) = O(g_1(n)) \quad and \quad f_2(n)) = O(g_2(n)) \quad then \quad f(n) = O(g_1(n) * g_2(n))$$

---
---

> [!Info]- References & MetaData Information
>
> Created On: 09 February 2025
>
> Status: #baby
>
> Keywords: #DataStructures #Algorithm #RuntimeAnalysis
>
> Tags: [[4 Indexes/DSA - Narasimha Karumanchi|DSA - Narasimha Karumanchi]]

---
---

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)