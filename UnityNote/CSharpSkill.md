### **=>  表达式**

后跟一个表达式，可以使用表达式来定义返回值



### **?.运算符**

在C#中，`?.` 运算符被称为 "null 条件运算符"。当你使用 `?.` 运算符时，它允许你在调用成员访问（例如方法调用或属性访问）之前，对左侧的对象是否为 `null` 进行检查。

在你提供的代码片段中：

```
StateChanged?.Invoke(this, new InventorySlotStateChangedArgs(_state, _active));
```

这里的 `StateChanged` 是一个事件，它在概念上类似于一个委托，可以有零个、一个或多个订阅者。如果 `StateChanged` 没有订阅者（即它的值为 `null`），那么 `?.` 运算符会使得 `Invoke` 方法调用被忽略，因此不会抛出 `NullReferenceException` 异常。如果 `StateChanged` 不是 `null`，即有至少一个订阅者，那么 `Invoke` 方法将被调用，通知所有订阅者状态发生了变化。

简而言之，`?.` 运算符的作用是：

- 如果左侧对象不为 `null`，则执行成员访问。
- 如果左侧对象为 `null`，则不执行成员访问，整个表达式的结果也为 `null`，并且不会产生异常。





### 迭代器

- `yield return`：在迭代中提供下一个值，如以下示例所示：

  ```csharp
  foreach (int i in ProduceEvenNumbers(9))
  {
      Console.Write(i);
      Console.Write(" ");
  }
  // Output: 0 2 4 6 8
  
  IEnumerable<int> ProduceEvenNumbers(int upto)
  {
      for (int i = 0; i <= upto; i += 2)
      {
          yield return i;
      }
  }
  ```





