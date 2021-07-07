using System;
using UnityEngine;
using rvinowise.unity.extensions;
using System.Collections.Generic;

namespace rvinowise.unity.ui.table {

[RequireComponent(typeof(Canvas))]
public class Table:MonoBehaviour {

    public Table_cell table_cell_prefab;
    private Canvas canvas;

    private List<Table_cell> cells = new List<Table_cell>();

    void Awake() {
        canvas = GetComponent<Canvas>();
    }
    public void add_item(
        MonoBehaviour in_item
    ) {
        Table_cell cell = create_cell();
        cell.put_item(in_item);
    }

    private Table_cell create_cell() {
        Table_cell cell = table_cell_prefab.get_from_pool<Table_cell>();
        /* cell.name = 
            String.Format("canvas {0}",in_item.name); */
        cell.transform.SetParent(canvas.transform, false);
        cells.Add(cell);
        return cell;
    }

    public void remove_item(
        MonoBehaviour in_item
    ) {
        Table_cell removed_cell = null;
        foreach(Table_cell cell in cells) {
            if (cell.item == in_item) {
                removed_cell = cell;
                
            }
        }
        if (removed_cell != null) {
            cells.Remove(removed_cell);
            removed_cell.destroy();
        }
        
    }
}
} 