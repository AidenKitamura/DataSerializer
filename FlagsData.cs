/* FlagsData includes the definition for global flags,
 * for example, CGs, ending leading flags, etc.
 */

using DataConstants

// TODO: define proper fields and manipulation methods.
public class FlagsData {

    static private bool[DataConstants.CGHighestId] _CG_UNLOCKED;
    
    // Unlock CG function. If successful, return true, else
    // return false.
    static public bool UnlockCG(int ID) {
        if (ID < DataConstants.CGLowestId || ID > DataConstants.CGHighestId) {
            return false;
        }
        if (this._CG_UNLOCKED[ID])
        {
            return false;
        }
        else
        {
            this._CG_UNLOCKED[ID] = true;
            return true;
        }
    }

    static public bool CGIsUnlocked(int ID) {
        return this._CG_UNLOCKED[ID];
    }
    
}