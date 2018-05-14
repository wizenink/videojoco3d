using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EazyTools.SoundManager;
using SoundCte;

namespace SoundUtil{
	public static class SoundUtil {

		private static int GenerateRandom(int amount){
			amount = amount--;
			System.Random rnd = new System.Random ();
			return rnd.Next (0, amount);
		}

		public static void PlayRandomSwordMiss(){
			switch (GenerateRandom(4)) 
			{
			case 0:
				SoundManager.PlaySound(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.EFFECT_SWORD_MISS_1), 1.0f, false, null);
				break;
			case 1:
				SoundManager.PlaySound(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.EFFECT_SWORD_MISS_2), 1.0f, false, null);
				break;
			case 2:
				SoundManager.PlaySound(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.EFFECT_SWORD_MISS_3), 1.0f, false, null);
				break;
			case 3:
				SoundManager.PlaySound(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.EFFECT_SWORD_MISS_4), 1.0f, false, null);
				break;
			}
		}

		public static void PlayRandomSkeletonHit(){
			switch (GenerateRandom(4)) 
			{
			case 0:
				SoundManager.PlaySound(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.EFFECT_HIT_BONE_1), 1.0f, false, null);
				break;
			case 1:
				SoundManager.PlaySound(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.EFFECT_HIT_FLESH_1), 1.0f, false, null);
				break;
			case 2:
				SoundManager.PlaySound(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.EFFECT_HIT_FLESH_2), 1.0f, false, null);
				break;
			case 3:
				SoundManager.PlaySound(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.EFFECT_HIT_FLESH_3_HEAVY), 1.0f, false, null);
				break;
			}
		}

		public static void PlayRandomSkeletonWhisp(Transform transform){
			switch (GenerateRandom(4)) 
			{
			case 0:
				SoundManager.PlaySound(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.EFFECT_SKELETON_WHISPER_1), 1.0f, false, transform);
				break;
			case 1:
				SoundManager.PlaySound(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.EFFECT_SKELETON_WHISPER_2), 1.0f, false, transform);
				break;
			case 2:
				SoundManager.PlaySound(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.EFFECT_SKELETON_WHISPER_3), 1.0f, false, transform);
				break;
			case 3:
				SoundManager.PlaySound(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.EFFECT_SKELETON_WHISPER_4), 1.0f, false, transform);
				break;
			}
		}

		public static void PlayRandomFleshHit(){
			switch (GenerateRandom(4)) 
			{
			case 0:
				SoundManager.PlaySound(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.EFFECT_HIT_FLESH_1), 1.0f, false, null);
				break;
			case 1:
				SoundManager.PlaySound(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.EFFECT_HIT_FLESH_2), 1.0f, false, null);
				break;
			case 2:
				SoundManager.PlaySound(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.EFFECT_HIT_FLESH_3_HEAVY), 1.0f, false, null);
				break;
			case 3:
				SoundManager.PlaySound(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.EFFECT_HIT_FLESH_4_HEAVY), 1.0f, false, null);
				break;
			}
		}

		public static void PlayRandomMusic(){
			switch (GenerateRandom(4)) 
			{
			case 0:
				SoundManager.PlayMusic(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.MUSICA1_SOUND), 0.3f, true, false);
				break;
			case 1:
				SoundManager.PlayMusic(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.MUSICA2_SOUND), 0.3f, true, false);
				break;
			case 2:
				SoundManager.PlayMusic(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.MUSICA3_SOUND), 0.3f, true, false);
				break;
			case 3:
				SoundManager.PlayMusic(SoundCte.SoundCte.LoadAudioClip(SoundCte.SoundCte.MUSICA4_SOUND), 0.3f, true, false);
				break;
			}
		}
	}
}
