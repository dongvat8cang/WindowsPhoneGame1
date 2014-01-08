using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.WorldClasses
{
    public class WorldManager
    {
        #region Field Region

        readonly Dictionary<string, TilesetData> tilesets;
        readonly Dictionary<string, MapLayerData> mapLayers;
        readonly Dictionary<string, MapData> mapData;

        #endregion

        #region Property Region

        public Dictionary<string, TilesetData> Tilesets
        {
            get { return tilesets; }
        }

        public Dictionary<string, MapLayerData> MapLayers
        {
            get { return mapLayers; }
        }

        public Dictionary<string, MapData> Maps
        {
            get { return mapData; }
        }

        #endregion

        #region Constructor Region

        public WorldManager()
        {
            tilesets = new Dictionary<string, TilesetData>();
            mapLayers = new Dictionary<string, MapLayerData>();
            mapData = new Dictionary<string, MapData>();
        }

        #endregion

        #region Method Region
        #endregion

        #region Virtual Method region
        #endregion
    }
}
