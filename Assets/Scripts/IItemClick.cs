using UnityEngine;

public class ItemClick : IItemClick {
    public event IItemClick.eventHandlerGameObject onItemClick;

    public void invokeItemClick(GameObject gObj) {
        onItemClick.Invoke(gObj);
    }

}