using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float perfectDist;
    public float greatDist;
    public float okDist;
    public float badDist;

    public GameObject arrows;
    public int health;
    public bool dead;

    public float upY;
    public float downY;
    public float neutralY;

    private Transform[] all_arrows;
    private int counter;
    private int combo;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        all_arrows = arrows.GetComponentsInChildren<Transform>();
        counter = 0;
        combo = 1;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0) {
            dead = true;
        }

        int quality = 0;
        bool upPress = false;
        bool downPress = false;
        bool leftPress = false;
        bool rightPress = false;

        counter--;

        if(counter <= 0) {
            transform.Find("bad").gameObject.SetActive(false);
            transform.Find("ok").gameObject.SetActive(false);
            transform.Find("great").gameObject.SetActive(false);
            transform.Find("perfect").gameObject.SetActive(false);
        }

        float x = transform.position.x;
        float z = transform.position.z;
        
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            upPress = true;
            transform.position = new Vector3(x, upY, z);
        } else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            downPress = true;
            transform.position = new Vector3(x, downY, z);
        } else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            leftPress = true;
        } else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            rightPress = true;
        }

        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) {
            transform.position = new Vector3(x, neutralY, z);
        } else if(Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) {
            transform.position = new Vector3(x, neutralY, z);
        }
        
        if(upPress || downPress) {
            all_arrows = arrows.GetComponentsInChildren<Transform>();
            for(int i = 0; i < all_arrows.Length; i++) {
                if(all_arrows[i].gameObject.activeSelf && ((all_arrows[i].gameObject.tag == "up" &&
                                                            upPress) ||
                                                            (all_arrows[i].gameObject.tag == "down" &&
                                                            downPress) ||
                                                            (all_arrows[i].gameObject.tag == "left" &&
                                                            leftPress) ||
                                                            (all_arrows[i].gameObject.tag == "right" &&
                                                            rightPress))) {
                    float arrow_x = all_arrows[i].position.x;
                    float arrow_y = all_arrows[i].position.y;
                    float player_x = gameObject.transform.position.x;
                    float player_y = gameObject.transform.position.y;
                    float distance = Mathf.Sqrt((player_x - arrow_x) * (player_x - arrow_x) + 
                                            (player_y - arrow_y) * (player_y - arrow_y));
                    if(distance <= perfectDist) {
                        quality = 3;
                        all_arrows[i].gameObject.SetActive(false);
                        break;
                    } else if (distance <= greatDist) {
                        quality = 2;
                        all_arrows[i].gameObject.SetActive(false);
                        break;
                    } else if (distance <= okDist) {
                        quality = 1;
                        all_arrows[i].gameObject.SetActive(false);
                        break;
                    }
                }
            }

            if(quality ==  0) {
                transform.Find("bad").gameObject.SetActive(true);
                health--;
                counter = 500;
                combo = 1;
            } else if(quality == 1) {
                transform.Find("ok").gameObject.SetActive(true);
                counter = 500;
                combo += 1;
                score += combo;
            } else if(quality == 2) {
                transform.Find("great").gameObject.SetActive(true);
                counter = 500;
                combo += 2;
                score += combo;
            } else if(quality == 3) {
                transform.Find("perfect").gameObject.SetActive(true);
                counter = 500;
                combo += 3;
                score += combo;
            }
        }
    }

    void OnTriggerEnter(Collider col) {
        if(col.tag == "Dodgeball") {
            health--;
        }
    }
}
