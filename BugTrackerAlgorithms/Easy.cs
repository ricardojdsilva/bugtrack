using System;
using System.Collections.Generic;

namespace BugTrackerAlgorithms
{
    public class Easy
    {
        //'(){}[]',

        public bool IsValidParentheses(string param)
        {
            //CODE HERE
            int s = param.Length;

            string first = "";
            string last = "";
            Dictionary<char, char> parameters = new Dictionary<char, char>();
            parameters.Add('(', ')');
            parameters.Add('{', '}');
            parameters.Add('[', ']');
            bool isValid = false;

            for (int i = 0; i < s; i++)
            {
               
                if (parameters.ContainsKey(param[i]))
                {
                   if (i <  s)
                    {
                        if (parameters[param[i]] == param[i+1])
                        {
                            isValid = true;
                        } else
                        {
                            isValid = false;
                            return false;
                        }

                        
                    }
                }

                
               /* if (param[i] == '(')
                {
                    first = param[i].ToString();
                } else if (param[i] == '[')
                {
                    first = param[i].ToString();
                } else if (param[i] == '{')
                {
                    first = param[i].ToString();
                }

                if (param[i] == ')')
                {
                    if (first == "(")
                    {
                        if (i == s)
                        {
                        return true;
                        }

                    }
                } else  if (param[i] == ']')
                {
                    if (first == "[")
                    {
                        if (i == s)
                        {
                            return true;
                        }
                    }
                } else if (param[i] == '}')
                {
                    if (first == "{")
                    {
                        if (i == s)
                        {
                            return true;
                        }
                    }
                } else
                {
                    if (i == s)
                    {
                        return false;
                    } 
                   
                }*/


            }

            return isValid;

                //throw new NotImplementedException();
        }

        public int[] TwoSum(int[] nums, int target)
        {
            //CODE HERE
            throw new NotImplementedException();
        }

        public int RemoveElement(int[] nums, int val)
        {
            //CODE HERE
            throw new NotImplementedException();
        }
    }
}
