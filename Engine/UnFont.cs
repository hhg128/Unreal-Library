﻿using UELib.Core;

namespace UELib.Engine
{
	/// <summary>
	/// Unreal Font.
	/// </summary>
	[UnrealRegisterClass]
	public class UFont : UObject, IUnrealViewable
	{
		private struct FontCharacter : IUnrealDeserializableClass
		{
			private int _StartU;
			private int _StartV;
			private int _USize;
			private int _VSize;
			byte _TextureIndex;

			public void Deserialize( IUnrealStream stream )
			{
				_StartU = stream.ReadInt32();
				_StartV = stream.ReadInt32();

				_USize = stream.ReadInt32();
				_VSize = stream.ReadInt32();

				_TextureIndex = stream.ReadByte();
			}
		};

		private UArray<FontCharacter> _Characters;

		protected override void Deserialize()
		{
			base.Deserialize();

			_Characters = new UArray<FontCharacter>( _Buffer );

			// Textures

			// Kerning
			_Buffer.ReadInt32();

			// Remap

			_Buffer.UR.ReadBoolean();
		}
	}
}