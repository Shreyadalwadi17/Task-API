using System.Collections;

                    for (int i = 0; i < root.articles.Count; i++)
                    {
                        GameObject obj = Instantiate(btnprefeb, parent);
                        obj.GetComponentInChildren<TMP_Text>().text += root.articles[i].author;
                        //await Task2();
                    }


        await Task.WhenAll(Task1(), Task3(), Task4());
     

    }
        await Task.Delay(1000);

        await Task.Delay(5000);
        Debug.Log(root.articles[2].title);

    }
        await Task2();
        Debug.Log("Task 3 completed");

    }
    private async Task Task4()
        await Task.Delay(1000);
        Debug.Log("Task 4 completed");
    }