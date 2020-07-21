﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ColourfulFlashPoints
{
    public static class TransformExtension
    {
        public static Transform findChild(this Transform transform, string name)
        {
            foreach (Transform childTransform in transform)
            {
                if (childTransform.name == name)
                {
                    return childTransform;
                }

                Transform possibleTransform = findChild(childTransform, name);
                if (possibleTransform != null)
                {
                    return possibleTransform;
                }
            }

            return null;
        }
    }
}
