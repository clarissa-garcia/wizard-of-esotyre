using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private string name;
    private string imageName;
    private int quantity;
    private GameObject physical;

    public Item(string nameIn, string imageNameIn, int quantityIn, string physicalIn)
    {
        setName(nameIn);
        setImageName(imageNameIn);
        setQuantity(quantityIn);
        setPhysical(physicalIn);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setName(string nameIn)
    {
        this.name = nameIn;
    }
    public void setImageName(string imageNameIn)
    {
        this.imageName = imageNameIn;
    }
    public void setQuantity(int quantityIn)
    {
        this.quantity = quantityIn;
    }
    public void setPhysical(string physicalIn)
    {
        this.physical = physicalIn;
    }
}
