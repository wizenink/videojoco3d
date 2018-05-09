public static class SoundConstants{

	//effects
	public const string EFFECT_FLESH_BREAK_1 		= "Effects/Effect_Flesh_Break_1.mp3";
	public const string EFFECT_FLESH_BREAK_2 		= "Effects/Effect_Flesh_Break_2.mp3";
	public const string EFFECT_FLESH_BREAK_3 		= "Effects/Effect_Flesh_Break_3.mp3";
	public const string EFFECT_HIT_BONE_1 			= "Effects/Effect_Hit_Bone_1.mp3";
	public const string EFFECT_HIT_BONE_2			= "Effects/Effect_Hit_Bone_2.mp3";
	public const string EFFECT_HIT_BONE_3 			= "Effects/Effect_Hit_Bone_3.mp3";
	public const string EFFECT_HIT_BONE_4 			= "Effects/Effect_Hit_Bone_4.mp3";
	public const string EFFECT_HIT_DRY_1 			= "Effects/Effect_Hit_Dry_1.mp3";
	public const string EFFECT_HIT_DRY_2  			= "Effects/Effect_Hit_Dry_2.mp3";
	public const string EFFECT_HIT_DRY_3  			= "Effects/Effect_Hit_Dry_3_Heavy.mp3";
	public const string EFFECT_HIT_FLESH_1 			= "Effects/Effect_Hit_Flesh_1.mp3";
	public const string EFFECT_HIT_FLESH_2 			= "Effects/Effect_Hit_Flesh_2.mp3";
	public const string EFFECT_HIT_FLESH_3_HEAVY 	= "Effects/Effect_Hit_Flesh_3_Heavy.mp3";
	public const string EFFECT_HIT_FLESH_4_HEAVY 	= "Effects/Effect_Hit_Flesh_4_Heavy.mp3";
	public const string EFFECT_SKELETON_WHISPER_1 	= "Effects/Effect_Skeleton_Whisper_1.mp3";
	public const string EFFECT_SKELETON_WHISPER_2 	= "Effects/Effect_Skeleton_Whisper_2.mp3";
	public const string EFFECT_SKELETON_WHISPER_3 	= "Effects/Effect_Skeleton_Whisper_3.mp3";
	public const string EFFECT_SKELETON_WHISPER_4 	= "Effects/Effect_Skeleton_Whisper_4.mp3";
	public const string EFFECT_SKELETON_WHISPER_5 	= "Effects/Effect_Skeleton_Whisper_5.mp3";
	public const string EFFECT_SWORD_MISS_1 		= "Effects/Effect_Sword_Miss_1.mp3";
	public const string EFFECT_SWORD_MISS_2 		= "Effects/Effect_Sword_Miss_2.mp3";
	public const string EFFECT_SWORD_MISS_3 		= "Effects/Effect_Sword_Miss_3.mp3";
	public const string EFFECT_SWORD_MISS_4 		= "Effects/Effect_Sword_Miss_4.mp3";
	public const string EFFECT_WALKING_SAND_FAST 	= "Effects/Effect_Walking_Sand_Fast.mp3";
	public const string EFFECT_WALKING_SAND_SLOW 	= "Effects/Effect_Walking_Sand_Slow.mp3";

	//menu
	public const string CLICK_SOUND 		= "GUI/click.wav";
	public const string CLICK_2_SOUND		= "GUI/click_2.wav";
	public const string LOAD_SOUND			= "GUI/load.wav";
	public const string MISC_MENU_SOUND		= "GUI/misc_menu.wav";
	public const string MISC_MENU_2_SOUND	= "GUI/misc_menu_2.wav";
	public const string MISC_MENU_3_SOUND	= "GUI/misc_menu_3.wav";
	public const string MISC_MENU_4_SOUND	= "GUI/misc_menu_4.wav";
	public const string MISC_SOUND_SOUND	= "GUI/misc_sound.wav";
	public const string NEGATIVE_SOUND		= "GUI/negative.wav";
	public const string NEGATIVE_2_SOUND	= "GUI/negative_2.wav";
	public const string POSITIVE_SOUND		= "GUI/positive.wav";
	public const string SAVE_SOUND			= "GUI/save.wav";
	public const string SHARP_ECHO_SOUND	= "GUI/sharp_eco.wav";
	
	//musica
	public const string MUSICA1_SOUND = "Music/Music1.mp3";
	public const string MUSICA2_SOUND = "Music/Music2.mp3";
	public const string MUSICA3_SOUND = "Music/Music3.mp3";
	public const string MUSICA4_SOUND = "Music/Music4.mp3";
	public const string MUSICA5_SOUND = "Music/Music5.mp3";
	public const string MUSICA6_SOUND = "Music/Music6.mp3";


	public AudioClip loadAudioClip (String constantSoundName){
		return Resources.Load<AudioClip>("Sound/"+constantSoundName);
	}
}





//https://answers.unity.com/questions/309833/load-audio-files-with-resourcesload-and-play-them.html