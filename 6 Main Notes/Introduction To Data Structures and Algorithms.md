# Introduction To Data Structures and Algorithms

> [!my-custom-callout-one] Table of Contents:
> 
> - Introduction
> - DS and ADT
> - Algorithm
> - Algorithm Analysis

> [!Content]
>
> ## Introduction
>
> <br>
>
> **Variables:**
> Named Storage Locations that hold values or data.
>
> **Constants:**
> Immutable Named Storage Locations that hold values or data. Unlike variables constants remain unmodified throughout their scope of existence.
>
> **Data Type:**
> Classification of values that tells the computer how to represent the data
>
> ```mermaid
>  graph TD;
>    DT["Data Types"]
>    SDT["System Defined Data Types"]
>    UDT["User Defined Data Types"]
>
>    DT --> SDT
>    DT --> UDT
> ```

> [!content]
>
> ## Data Structures and Abstract Data Types
>
> <br>
>
> > [!my-definition-callout] Data Structure
> >
> > Specialised formats for organising, processing, retrieving, and storing data defining the relationship between data and the operations that can be performed on the data.
> >
> > _Commonly used Data Structures:_
> >
> > - Arrays
> > - Linked Lists
> > - Linked List based Stack,
> > - Array based Stack and more ...
>
> > [!Note]
> >
> > Classifying broadly, there are two types of Data Structures
> >
> > - _Linear Data Structures:_ Elements are accessible in sequential order but may or may not be stored in sequential order. Array, List, Stack, Queue, ...
> > - _Non Linear Data Structures:_ Elements are stored and accessible in non-linear order. Tree, Graph, ...
>
> > [!my-definition-callout] Abstract Data Type (ADT)
> >
> > - A conceptual model for Data Structures defining the type of data stored, the operations supported on them, and the types of parameters of the operations, without specifying how these operations are implemented or how data is organised in memory.
> >
> > _Commonly used ADTs:_
> >
> > - Linked Lists
> > - Stacks
> > - Queues
> > - Binary Trees
> > - Priority Queues
> > - Dictionaries
> > - Disjoined Sets
> > - Hash Tables, and more ...

> [!content]
>
> ## Question
>
> <br>
>
> > [!Question]- How do Data Structures and Abstract Data Types relate to each other?
> >
> > **Answer:**
> >
> > Similarities Between Abstract Data Types (ADTs) and Data Structures
> >
> > - Both are used to represent and organise data.
> > - Both define operations that can be performed on the data (e.g., insertion, deletion, searching).
> > - Both are fundamental building blocks in computer science for designing and implementing algorithms.
> >
> > Differences Between Abstract Data Types (ADTs) and Data Structures.
> >
> > | **Feature**        | **Abstract Data Type (ADT)**   | **Data Structure**                                    |
> > |:---------------|:---------------------------|:--------------------------------------------------|
> > | _**Focus**_          | What it does (operations)  |How it's implemented (representation)              |
> > | _**Level**_          | High-level, conceptual     |Low-level, concrete                                |
> > | _**Implementation**_ | No specific implementation |Specific implementation (e.g., array, linked list) |
> > | _**Example**_        | Stack (push, pop)          |Array-based Stack, Linked List-based Stack         |
>
> > [!NOTE]-
> >
> > A single ADT can have multiple data structure implementations, allowing for flexibility in choosing the most suitable representation for a given problem.

---

> [!content]
>
> ## Algorithms
>
> <br>
>
> > [!my-definition-callout] Algorithm
> >
> > Step by Step unambiguous set of instructions to solve a problem or achieve an outcome.
>
> > [!Note] Merits of Algorithm
> >
> > Criteria to judge merits of an algorithm
> >
> > - **Correctness / Accuracy**
> > - **Efficiency**
> > - Scalability
> > - Complexity or Simplicity
> > - Adaptability
> > - Ease of Implementation
>
> > [!attention] Correctness vs Accuracy
> >
> > ### Correctness:
> >
> > Algorithm must produce logically sound and error-free results for all valid inputs to be called correct.
> >
> > - **Logical soundness:** Does the algorithm follow a sound and consistent set of rules?
> > - **Absence of errors:** Are there any bugs, logical inconsistencies, or edge cases where the algorithm produces incorrect results?
> > - **Compliance with specifications:** Does the algorithm fulfil all the requirements and constraints outlined in its design?
> >
> > ---
> >
> > ### Accuracy
> >
> > Algorithm must produce outputs that match with true or expected value, especially in cases where there might be some inherent uncertainty or approximation involved.
> >
> > - **Closeness to the desired outcome:** How close are the algorithm's results to the ideal or most accurate solution?
> > - **Minimization of errors:** How effectively does the algorithm reduce errors or deviations from the true value?
> > - **Approximation quality:** If the algorithm involves approximations or heuristics, how accurate are those approximations?

---

> [!content]
> ## Algorithm Analysis
>
> <br>
>
> > [!Question] Why Analyse an Algorithm?
> >
> > Algorithm analysis is essential for achieving optimal performance, ensuring efficient resource utilisation, guaranteeing the reliability of the functionality, and predicting behaviour across diverse scenarios.
>
> > [!my-definition-callout] Runtime analysis
> >
> > The process of determining how long an algorithm takes to execute as a function of the input size.
> >
> > Runtime Analysis helps us understand how the algorithm's performance scales with larger inputs, enabling us to choose the most efficient algorithms for specific tasks and optimize resource usage.
>
> > [!NOTE] Key Aspects of Runtime Analysis
> >
> > - Asymptotic Notation (Big O, Big Omega, Big Theta)
> > - Conducting Analysis via practical implementation (Time/Space Profiling)
> > - Average case and worst case analysis
> > - Practical application (Algorithm selection, optimization, resource allocation)
>
> > [!NOTE] Key Concepts:
> >
> > - Size of Problem
> >     - Size of input array
> >     - Polynomial degree
> >     - Number of Elements in Matrix
> >     - number of bits in a binary expression
> >     - Vertices and edges in graph ...
> > - Rate of Growth
> >     - The scaling behaviour of an algorithm's runtime with increasing input.
> >     - The rate of change in an algorithm's runtime as a function of input size.
> > - Time Complexity
> > - Space Complexity
>
> > [!NOTE] Rate of Growth
> >
> > - Size of Problem
> >     - Size of input array
> >     - Polynomial degree
> >     - Number of Elements in Matrix
> >     - number of bits in a binary expression
> >     - Vertices and edges in graph ...
> > - Rate of Growth
> >     - The scaling behaviour of an algorithm's runtime with increasing input.
> >     - The rate of change in an algorithm's runtime as a function of input size.
> > - Time Complexity
> > - Space Complexity
> >
> > ```mermaid
> >  graph LR;
> >    A["2^(2^n)"] --> B[n!]
> >    B --> C[4^n]
> >    C --> D[2^n]
> >    D --> E[n^3]
> >    E --> F[n^2]
> > ```
> >
> > ```mermaid
> >  graph RL;
> >    F[n^2] --> G[n log n]
> >    G --> H[log n!]
> >    H --> I[n]
> >    I --> J[√n]
> >    J --> K[log^2 n]
> > ```
> >
> > ```mermaid
> >  graph LR;
> >    K[log^2 n] --> L[log n]
> >    L --> M[√log n]
> >    M --> N[log log n]
> >    N --> O[1]
> > ```
> >
>
> > [!NOTE] Types Of analysis
> >
> > - *Worst Case:*
> >   - Input for which algo runs the slowest
> > - _Best Case:_
> >   - Input for which algo runs the fastest
> > - _Average Case:_
> >   - Provides prediction for running time of algorithm
> >   - Runs many times with different inputs that comes from a distribution that generates the input and calculates average of all these runs
> >   - Assumes that the input is random.

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
