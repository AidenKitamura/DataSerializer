/* This file contains the general manager for data
 * which includes but not limited to player data, 
 * monster data, etc. One should only call this cl-
 * ass, but not the others. However, interfaces to 
 * create objects are provided.
 */

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using MonsterEntity;
using CardEntity;
using DataConstants;

public class DataManager 
{
    
    // only one instance for data manager is allowed.
    static private DataManager _DATA_MANAGER;

    // actual data defined here:
    // 
    // If you want to add more data fields, add as f-
    // ollows:
    // 
    // private Dictionary<string, YOUR_CLASS> NAME;
    // 
    // Except for that, define respective get and set
    // methods for these variables, but do note that 
    // you should only use get to get an entry, not 
    // the entire dictionary.
    // 
    // Do note that you need to import them manually
    // by addding "using xxx;" at the beginning of this
    // file.
    // 
    // Do also note that you need to define respective
    // constants, e.g. filenames, in DataConstants file
    // and define classes in respective files.
    //
    // TODO: Add respective data struct and methods

    private Dictionary<string, CardEntity> cardData;
    private Dictionary<string, MonsterEntity> monsterData;

    private DataManager() 
    {
        try
        {
            // read files into data classes
            BinaryFormatter b = new BinaryFormatter();

            File cardFile = new File(DataConstants.CardDataDir);
            Stream cardStream = cardFile.Open(FileMode.Open);
            this.cardData = (Dictionary<string, CardEntity>) b.Deserialize(cardStream);
            cardFile.Close();

            File monsterFile = new File(DataConstants.MonsterDataDir);
            Stream monsterStream = monsterFile.Open(FileMode.Open);
            this.monsterData = (Dictionary<string, MonsterEntity>) b.Deserialize(monsterStream);
            monsterFile.Close();

        }
        catch (System.Exception)
        {
            throw;
        }
    }

    static public DataManager getDataManager() 
    {
        if (_DATA_MANAGER is null)
        {
            _DATA_MANAGER = DataManager();
        }
        return _DATA_MANAGER;
    }

    // TODO: GetCard, GetMonster Method

    // TODO: Add prompt error handling

    public T GetCardAttr<T>(string cardName, string attr)
    {
        try
        {
            T returnResult = this.cardData[cardName][attr];
            return returnResult;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public T GetMonsterAttr<T>(string monsterName, string attr)
    {
        try
        {
            T returnResult = this.monsterData[monsterName][attr];
            return returnResult;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

}