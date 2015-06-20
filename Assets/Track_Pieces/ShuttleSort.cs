using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShuttleSort
    {
        /*
         * purpose
         * to provide sorting methods to the main menu so it can sort the runners into a team
         */
        // reference to the instance of this class
        public static ShuttleSort singleton;

        // integer to hold current position within the array
        int currentPos = 0;
        // variables to hold the temporary contents of an element in the array
        int firstItem = 0;
       	int secondItem = 0;
        // boolean to record when a pass of the algorithm is completed
        bool passDone = false;

        // efficiency variables to score how many times data was moved and compared
        // just to check for any problems with the sort
        int totalSwaps = 0;
        int totalChecks = 0;

        // required as an initialiser for the class, even though nothing happens upon creation
        public ShuttleSort()
        {
            
        }

        // used to reset the variables before each sort
        void ClearVars()
        {
            currentPos = 0;
            totalSwaps = 0;
            totalChecks = 0;
            passDone = false;
        }
		
		
		public List<int> SortTowerTargets(List<int> listToSort){
			// reset the variables ready for another sort
			ClearVars();
			// check that our array actually contains more than 1 item
			if (listToSort.Count > 1)
			{
				// compare first and second
				currentPos = 1;
				for (int i = 1; i < listToSort.Count; i++)
				{
					currentPos = i;
					passDone = false;
				
					//keep comparing until a pass is made
					while (passDone == false) {
						// get the items to be compared in this pass
						secondItem = listToSort[currentPos];
						firstItem = listToSort[currentPos - 1];
						totalChecks ++;
						// check if the first item is smaller than the second
						if (CreepManager.GetCreepWithID(firstItem).totalDist < CreepManager.GetCreepWithID(secondItem).totalDist)
						{
							// swap the numbers
							listToSort[currentPos] = firstItem;
							listToSort[currentPos - 1] = secondItem;
							
							// reduce the current position by 1
							currentPos--;
							// check if the current position is at the end of the list, since if we have reached it, stop the pass
							totalSwaps++;
							if (currentPos == 0)
							{
								passDone = true;
							}
						}
						else
						{
							passDone = true;
						}
					}
				}
			}
			// its done!
			// debug the result of ths sort
			Debug.Log("Your sorted array is:");
			for (int i = 0; i < listToSort.Count; i++)
			{
				Debug.Log(listToSort[i]);
			}
			// show efficiency in the output log
			Debug.Log("There were " + totalChecks + " checks. And " + totalSwaps + " swaps.");
			return listToSort;
		}
		
        // public function so that it can be called by anything to sort a specific array
        public int[] SortArray(int[] arrayToSort)
        {
            // reset the variables ready for another sort
            ClearVars();
            // check that our array actually contains more than 1 item
            if (arrayToSort.Length > 1)
            {
                // compare first and second
                currentPos = 1;
                for (int i = 1; i < arrayToSort.Length; i++)
                {
                    currentPos = i;
                    passDone = false;

                    //keep comparing until a pass is made
                    while (passDone == false) {
                        // get the items to be compared in this pass
                        secondItem = arrayToSort[currentPos];
                        firstItem = arrayToSort[currentPos - 1];
                        totalChecks ++;
                        // check if the first item is smaller than the second
                        if (firstItem > secondItem)
                        {
                            // swap the numbers
                            arrayToSort[currentPos] = firstItem;
                            arrayToSort[currentPos - 1] = secondItem;
                            
                            // reduce the current position by 1
                            currentPos--;
                            // check if the current position is at the end of the list, since if we have reached it, stop the pass
                            totalSwaps++;
                            if (currentPos == 0)
                            {
                                passDone = true;
                            }
                        }
                        else
                        {
                            passDone = true;
                        }
                    }
                }
            }
                // its done!
                // debug the result of ths sort
            Debug.Log("Your sorted array is:");
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                Debug.Log(arrayToSort[i]);
            }
            // show efficiency in the output log
            Debug.Log("There were " + totalChecks + " checks. And " + totalSwaps + " swaps.");
            return arrayToSort;
        }
    }
