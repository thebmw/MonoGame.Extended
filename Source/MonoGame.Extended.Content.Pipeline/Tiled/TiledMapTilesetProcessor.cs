﻿using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGame.Extended.Content.Pipeline.Tiled
{
	[ContentProcessor(DisplayName = "Tiled Map Tileset Processor - MonoGame.Extended")]
	public class TiledMapTilesetProcessor : ContentProcessor<TiledMapTilesetContent, TiledMapTilesetContent>
	{
		public override TiledMapTilesetContent Process(TiledMapTilesetContent tileset, ContentProcessorContext context)
		{
			try
			{
				ContentLogger.Logger = context.Logger;

				ContentLogger.Log($"Processing tileset '{tileset.Name}'");
				tileset.Image.Content = context.BuildAndLoadAsset<Texture2DContent, Texture2DContent>(new ExternalReference<Texture2DContent>(tileset.Image.Source), "");
				ContentLogger.Log($"Processed tileset '{tileset.Name}'");

				return tileset;
			}
			catch (Exception ex)
			{
				context.Logger.LogImportantMessage(ex.Message);
				return null;
			}
		}
	}
}
