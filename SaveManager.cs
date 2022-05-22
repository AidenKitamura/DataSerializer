/* This file contains program to manage player's save
 * data, which includes but not limited to save data 
 * verification, load/save function, etc.
 */

using SaveData;
using DataConstants;

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager {
    // TODO: implement save and load function
    static private SaveManager _SAVE_MANAGER;

    // Read From SaveDir and instantiate object
    static public SaveManager ReadFromDat() {
        
        if (_SAVE_MANAGER is null) {
            BinaryFormatter b = new BinaryFormatter();

            File saveFile = new File(DataConstants.SaveDir);
            Stream saveStream = saveFile.Open(FileMode.Open);
            this._SAVE_MANAGER = (SaveManager) b.Deserialize(saveStream);
            saveFile.Close();
        }
        
        return _SAVE_MANAGER;
    }
}