using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Node", menuName = "Node")]
public class Node : MonoBehaviour /* : ScriptableObject*/
{
    [SerializeField] public string nodeName = "node name";
    [SerializeField] public string nodeIP = "0.0.0.0";

    [SerializeField] public List<Node> connectedNodes;
}
