> [!question] Why analyse an algorithm?
> 
> Algorithm analysis is essential for achieving optimal performance, ensuring efficient resource utilisation, guaranteeing the reliability of the functionality, and predicting behaviour across diverse scenarios.

> [!my-definition-callout] Runtime analysis
> 
> The process of determining how long an algorithm takes to execute as a function of the input size.
> 
> Runtime Analysis helps us understand how the algorithm's performance scales with larger inputs, enabling us to choose the most efficient algorithms for specific tasks and optimize resource usage.

> [!NOTE] Key Aspects of Runtime Analysis
> 
> - Asymptotic Notation (Big O, Big Omega, Big Theta)
> - Conducting Analysis via practical implementation (Time/Space Profiling)
> - Average case and worst case analysis
> - Practical application (Algorithm selection, optimization, resource allocation)

> [!NOTE] Key concepts
> 
> - Size of Problem
>     - Size of input array
>     - Polynomial degree
>     - Number of Elements in Matrix
>     - number of bits in a binary expression
>     - Vertices and edges in graph ...
> - Rate of Growth
>     - The scaling behaviour of an algorithm's runtime with increasing input.
>     - The rate of change in an algorithm's runtime as a function of input size.
> - Time Complexity
> - Space Complexity

> [!content] Rate of Growth
> ```mermaid
> graph LR;
>   A["2^(2^n)"] --> B[n!]
>   B --> C[4^n]
>   C --> D[2^n]
>   D --> E[n^3]
>   E --> F[n^2]
> ```
> 
> ```mermaid
> graph RL;
>   F[n^2] --> G[n log n]
>   G --> H[log n!]
>   H --> I[n]
>   I --> J[√n]
>   J --> K[log^2 n]
> ```
> 
> ```mermaid
> graph LR;
>   K[log^2 n] --> L[log n]
>   L --> M[√log n]
>   M --> N[log log n]
>   N --> O[1]
> ```
> 

> [!NOTE] Types Of Analysys
> 
> - _Worst Case:_
>     - Input for which algo runs the slowest
> - _Best Case:_
>     - Input for which algo runs the fastest
> - _Average Case:_
>     - Provides prediction for running time of algorithm
>     - Runs many times with different inputs that comes from a distribution that generates the input and calculates average of all these runs
>     - Assumes that the input is random.

---
---

> [!Info]- References & MetaData Information
>
> Created On: 08 February 2025
>
> Status: #baby
>
> Keywords: #DataStructures #AbstractDataTypes #Algorithm #RuntimeAnalysis
>
> Tags: [[4 Indexes/DSA - Narasimha Karumanchi|DSA - Narasimha Karumanchi]]

---
---

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)
