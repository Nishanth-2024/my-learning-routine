> [!my-definition-callout] Stack
>
> A stack is a *linear data structure* or *abstract data type* that stores a collection of elements in a specific order, and insertion and deletion are done at one end, adhering to the Last-In, First-Out (*LIFO*) principle.
>
> It's a way of organizing data where the last element added is the first one retrieved.

> [!NOTE] Stack as ADT
>
> The following operations make a stack an ADT. For simplicity , assume the data is an integer type.
>
> Main stack operations
>
> - *Push(T data)*: Inserts data onto stack.
> - *T Pop()*: Removes and returns the last inserted element from the stack.Auxiliary stack operations
> - *T Top()*: Returns the last inserted element without removing it.
> - *int Size()*: Returns the number of elements stored in the stack.
> - *bool IsEmptyStack()*: Indicates whether any elements are stored in the stack or not.
> - *bool IsFullStack()*: Indicates whether the stack is full or not.
