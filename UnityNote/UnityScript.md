



### MonoBehaviort

#### OnValidate

仅编辑器：当脚本被加载或Inspector的值被修改时调用

`TryGetComponent<T>(out T Component)`: 返回bool：是否存在该组件, 如果存在则输出变量Component

```c#
private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<GameItem>(out var gameItem)) return;
        _inventory.AddItem(gameItem.Pick());
    }
```

---

### Input

获取鼠标位置：

```
Input.mousePosition
//旧InputSystem的获取方式
```

```c#
Mouse.current.position.ReadValue()
    //新InputSystem的获取方式
```



按键识别：

```

```







```
RectTransformUtility.ScreenPointToWorldPointInRectangle()
```

**参数说明：**

- `rectTransform`：要转换坐标的 `RectTransform`。这通常是你想要检测点击或触摸事件的 UI 元素。
- `screenPosition`：屏幕空间的坐标点。这通常是从 `Input.mousePosition` 获取的鼠标位置，或者从 `PointerEventData.position` 获取的触摸位置。
- `camera`：用于视图转换的摄像机。如果 UI 是画布渲染模式（Canvas Render Mode）为 Screen Space - Overlay，则可能不需要这个参数，因为叠加模式下不需要摄像机。如果 UI 使用其他渲染模式，你可能需要指定一个摄像机来正确地进行坐标转换。
- `eventCamera`：这是一个可选参数，用于指定一个摄像机，当使用事件系统（如 `EventSystem`）时，该摄像机用于确定事件处理的上下文。

**返回值：**

- 方法返回转换后的坐标，这是一个 `Vector3` 值，表示在世界空间中的位置，相对于 `RectTransform` 的父对象。

---

### UI

**CanvasGroup**组件：可以调整透明度，设置是否可交互，是否阻挡射线, 如果阻挡射线Blocks Raycasts被设置为了false则该组件下的子物体都无法检测射线.





---

### Editor

#### ContextMenu

`ContextMenu()`属性是一个上下文菜单属性，它允许开发者在Unity编辑器中为任何继承自`MonoBehaviour`的类添加自定义菜单项。当你右键点击Unity编辑器中的一个对象时，会弹出一个上下文菜单，`ContextMenu()`属性允许你在这个菜单中添加自定义的选项。

**使用方法**

`ContextMenu()`属性通常与一个方法结合使用。以下是`ContextMenu()`的基本用法：

```
[ContextMenu("自定义菜单名称")]
private void CustomContextMenuFunction()
{
    // 这里写你想要执行的代码
    Debug.Log("自定义菜单项被点击了！");
}
```

**参数**

`ContextMenu()`属性可以接收一个或两个参数：

1. **菜单名称**：这是显示在上下文菜单中的名称。
2. **可选的菜单项ID**（可选）：如果提供了ID，可以用于区分多个菜单项。

如果提供了ID，语法如下：

```
[ContextMenu("自定义菜单名称", "菜单项ID")]
```



---

### GameObject

1. **GameObject.Instantiate()**:
   - 这是 Unity 中最常用的实例化方法。
   - 它可以用来实例化任何 GameObject，包括场景中的对象、预制件（Prefabs）以及从 Asset Bundle 加载的对象。
   - 这个方法会创建一个与原对象完全相同的副本，包括所有的组件和属性。
   - 使用 `GameObject.Instantiate()` 实例化的对象默认不会被添加到任何预制件的依赖关系中，它们是独立的实例。
2. **PrefabUtility.InstantiatePrefab()**:
   - 这个方法专门用于实例化预制件（Prefabs）。
   - 使用 `PrefabUtility.InstantiatePrefab()` 实例化的对象会与原预制件保持连接，这意味着如果原预制件被修改，实例化的对象也会自动更新以反映这些更改。
   - 这个方法通常用于需要保持实例与预制件同步的场景，例如，当你需要在编辑器中修改预制件，并希望所有实例都自动更新以反映这些更改时。
   - `PrefabUtility.InstantiatePrefab()` 返回的是实例化对象的引用，而不是实例对象本身。

​	

​	编辑器下删除所有子物体：

```c#
void DestroyAllChildrenInEditor(GameObject parent)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in children)
        {
            Undo.DestroyObjectImmediate(child.gameObject);
        }
    }
```



---

### Particle System

  

