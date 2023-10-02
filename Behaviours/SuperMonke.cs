﻿using System;
using System.Collections.Generic;
using UnityEngine;
using GorillaLocomotion;
using BepInEx;

namespace SuperMonke.Behaviours
{
    class SuperMonke : MonoBehaviour
    {
        Player player;
        private Rigidbody rb;
        private float speed = 1;


        private void Awake()
        {
            Console.WriteLine("super monke has awoken!! watch out!! (it's very scary)");
            player = Player.Instance;
            rb = player.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if(Plugin.instance.modEnabled && Plugin.instance.inRoom)
            {
                bool isLeft = InputHandler.GetInput(true, InputHandler.InputType.triggerButton) && InputHandler.GetInput(true, InputHandler.InputType.gripButton) && InputHandler.GetInput(true, InputHandler.InputType.primaryButton);
                bool isRight = InputHandler.GetInput(false, InputHandler.InputType.triggerButton) && InputHandler.GetInput(false, InputHandler.InputType.gripButton) && InputHandler.GetInput(false, InputHandler.InputType.primaryButton);

                Vector3 bodyToLeft = GorillaTagger.Instance.leftHandTransform.position - player.bodyCollider.transform.position;
                Vector3 bodyToRight = GorillaTagger.Instance.rightHandTransform.position - player.bodyCollider.transform.position;

                if (isLeft && isRight)
                {
                    if (speed < 32)
                        speed = (speed * 2) / 1.5f;
                    rb.useGravity = false;
                    rb.velocity = ((bodyToLeft + bodyToRight) / 2) * speed;
                }
                else
                {
                    rb.useGravity = true;
                    if(rb.velocity.magnitude > 2)
                        speed = rb.velocity.magnitude;
                }
            }
            else
                rb.useGravity = true;
        }
    }
}
