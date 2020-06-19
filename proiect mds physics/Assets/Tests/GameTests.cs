using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GameTests
    {
        //We'll wait 10 frames for every test to complete

        [UnityTest]
        public IEnumerator PlayerMovementForward_Works()
        {
            yield return new MonoBehaviourTest<PlayerMovementForward>();
            Assert.AreEqual(PlayerMovementForward.Condition, true);
        }

        [UnityTest]
        public IEnumerator PlayerMovementBackward_Works()
        {
            yield return new MonoBehaviourTest<PlayerMovementBackward>();
            Assert.AreEqual(PlayerMovementBackward.Condition, true);
        }

        [UnityTest]
        public IEnumerator PlayerMovementRight_Works()
        {
            yield return new MonoBehaviourTest<PlayerMovementRight>();
            Assert.AreEqual(PlayerMovementRight.Condition, true);
        }

        [UnityTest]
        public IEnumerator PlayerMovementLeft_Works()
        {
            yield return new MonoBehaviourTest<PlayerMovementLeft>();
            Assert.AreEqual(PlayerMovementLeft.Condition, true);
        }

        [UnityTest]
        public IEnumerator JumpTest_Works()
        {
            yield return new MonoBehaviourTest<JumpTest>();
            Assert.AreEqual(JumpTest.Condition, true);
        }

        [UnityTest]
        public IEnumerator CheckCoinRotation_Works()
        {
            yield return new MonoBehaviourTest<CoinTest>();
            Assert.AreEqual(CoinTest.Condition, true);
        }
    }

    public class PlayerMovementForward : MonoBehaviour, IMonoBehaviourTest
    {
        private static Vector3 InitialPosition = new Vector3(0, 0, 0);
        private static Vector3 NewPosition;
        private int frameCount;
        public bool IsTestFinished
        {
            get
            {
                return frameCount > 10;
            }
        }

        public static bool Condition
        {
            get
            {
                //to see if the player moved forward, based on Vector3 documentation, we need to check if Z component is bigger than 0 (as we started in Vector3(0, 0, 0)
                return NewPosition.z > 0;
            }
        }

        void Update()
        {
            NewPosition = InitialPosition;
            NewPosition += transform.forward * Time.fixedDeltaTime * 50f;
            frameCount++;
        }
    }

    public class PlayerMovementBackward : MonoBehaviour, IMonoBehaviourTest
    {
        private static Vector3 InitialPosition = new Vector3(0, 0, 0);
        private static Vector3 NewPosition;
        private int frameCount;
        public bool IsTestFinished
        {
            get
            {
                return frameCount > 10;
            }
        }

        public static bool Condition
        {
            get
            {
                //to see if the player moved forward, based on Vector3 documentation, we need to check if Z component is smaller than 0 (as we started in Vector3(0, 0, 0)
                return NewPosition.z < 0;
            }
        }

        void Update()
        {
            NewPosition = InitialPosition;
            NewPosition -= transform.forward * Time.fixedDeltaTime * 50f;
            frameCount++;
        }
    }

    public class PlayerMovementRight : MonoBehaviour, IMonoBehaviourTest
    {
        private static Vector3 InitialPosition = new Vector3(0, 0, 0);
        private static Vector3 NewPosition;
        private int frameCount;
        public bool IsTestFinished
        {
            get
            {
                return frameCount > 10;
            }
        }

        public static bool Condition
        {
            get
            {
                //to see if the player moved right, based on Vector3 documentation, we need to check if X component is bigger than 0 (as we started in Vector3(0, 0, 0)
                return NewPosition.x > 0;
            }
        }

        void Update()
        {
            NewPosition = InitialPosition;
            NewPosition += transform.right * Time.fixedDeltaTime * 50f;
            frameCount++;
        }
    }

    public class PlayerMovementLeft : MonoBehaviour, IMonoBehaviourTest
    {
        private static Vector3 InitialPosition = new Vector3(0, 0, 0);
        private static Vector3 NewPosition;
        private int frameCount;
        public bool IsTestFinished
        {
            get
            {
                return frameCount > 10;
            }
        }

        public static bool Condition
        {
            get
            {
                //to see if the player moved left, based on Vector3 documentation, we need to check if X component is smaller than 0 (as we started in Vector3(0, 0, 0)
                return NewPosition.x < 0;
            }
        }

        void Update()
        {
            NewPosition = InitialPosition;
            NewPosition -= transform.right * Time.fixedDeltaTime * 50f;
            frameCount++;
        }
    }

    public class CoinTest : MonoBehaviour, IMonoBehaviourTest
    {
        private static Quaternion Position;
        private int frameCount;
        public bool IsTestFinished
        {
            get
            {
                return frameCount > 10;
            }
        }

        public static bool Condition
        {
            get
            {
                //we check the angle rotation, as we started in (0, 0, 0) the y component must be different if a rotation was completed
                return Position.y > 0;
            }
        }

        // Update is called once per frame
        void Update()
        {
            var rotationVector = new Vector3(0, 0, 0);
            rotationVector.y += 2;
            transform.localRotation = Quaternion.Euler(rotationVector);
            Position = transform.localRotation;
            frameCount++;
        }
    }

    public class JumpTest : MonoBehaviour, IMonoBehaviourTest
    {
        private static Vector3 InitialPosition = new Vector3(0, 0, 0);
        private static Vector3 NewPosition;
        private int frameCount;
        public bool IsTestFinished
        {
            get
            {
                return frameCount > 10;
            }
        }

        public static bool Condition
        {
            get
            {
                //to see if the player jumped, based on Vector3 documentation, we need to check if Y component is bigger than 0 (as we started in Vector3(0, 0, 0)
                return NewPosition.y > 0;
            }
        }

        void Update()
        {
            NewPosition = InitialPosition;
            NewPosition += transform.up * 10f * 2.2f;
            frameCount++;
        }
    }
}
