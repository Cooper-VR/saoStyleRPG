using UnityEngine;

namespace SAOrpg.UI
{
    //idk why this couldnt be done aother way but it works
    public class confirmationWindowMaster : MonoBehaviour
    {
        public confirmationWindowControl window;
        public GameObject confirm;
        // Start is called before the first frame update
        void Start()
        {
            window = Instantiate(confirm, Vector3.zero, Quaternion.identity, transform).GetComponent<confirmationWindowControl>();
            window.gameObject.SetActive(false);
        }
    }
}
