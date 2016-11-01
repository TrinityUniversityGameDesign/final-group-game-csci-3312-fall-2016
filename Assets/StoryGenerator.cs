using UnityEngine;
using System.Collections;

public class StoryGenerator : MonoBehaviour {

    class MainCharacter
    {

    }

    /* The branching story:
     * Advanture can lead to being: (generate_opening)
     *     cursed, which leads to: (generate_cursed).
     *         All the men die, you die of old age. (generate_old)
     *         Or, you die too, a horrible death somehow. (generate_horrible)
     *             In either case, the treasure is abandoned somewhere.Which leads to the end state. (generate_abandoned).
     *     scorned, all your crew turns on you. Which leads to: (generate_scorned)
     *         You are killed, and the treasure is taken. By your crew. (generate_killed)
     *         Or, they leave you stranded to die somehwere. (generate_stranded)
     *             In Either case, the crew utlimately kill each other, leaving the treasure somewhere along the route home. Which leads to the end state. (generate_lost).
     *     In in the end, legends of this lost treasure have trickled around the world. (generate_legends).
    */     

    // Eventually need to move out of here into a file as a template (do I?).
    // The things in {} can be swapped out for similar words. 
    // When making it, have it so corresponding words still appear, etc.
    string generate_opening()
    {

        string s = "The great {absurdist} {explorer} {Schwifty Von Amrack} was noted for discovering the {staff} of {Alluhaasds} at the {great} {temple} of {Ushjdi}.";
        s += " However, {his} {forgotten} {discovery} was the discovery of the {pubescent} {medalion} of {Amadusos}, which {he} found after {winning} at the {Great} {Games} {at Osismosos}.";
        s += "This is not the tale of that discovery, but of what befell {him} after...";
        return s;
    }

    string generate_cursed()
    {
        string s = "However, there were {terrible} tales told of that {pubescent} {medalion}. Tales of a {horrible} {curse}, which befalls any who {fuck} that {pubescent} item.";
        s += "The stories told of being {burned alive} and being {gutted like a pig}, and {several} spoke of being {eternally ostricized by everyone who had pretended to love} you. ";
        s += "It did not initially inflict {Schwifty Von Amrack}, it instead hit {his} trusty {bear-man servant}. He was tragically {eternally ostricized by everyone who had pretended to love} {him}.";
        s += "Leaving {Schwifty Von Amrack} devastated. The curse ravaged the crew, until only the {absurdist} {explorer} {Schwifty Von Amrack} was left alone.";
        return s;
    }


    string generate_old() {
    
        string s = "Realizing the gravity of his {doom}, the {aburdist} {explorer} abandoned the {medalion}. He {prayed} that whatever {demonic} {gods} which {cursed} {Amadusos}'s {pubescent}";
        s += "{medalion}. He abandoned the {medalion}, and returned home to {the Kingslandistanian Empire}.";
        return s;
    }

    string generate_horrible()
    {
        string s = "Tragically, like it was too late for the crew, it was too late for that {aburdist} {Schwifty Von Amrack}, even after {he} had abandoned the {medalion}.";
        s += "The famous {explorer} was {cursed} by a fate more horrible than any of the fates spoken of in the tales.";
        s += "{Schwifty Von Amrack was {brutally} {drowned alive and resurrected before being eaten alive} by {minions} of {Amadusos} {him}self.";
        return s;
    }

    string generate_abandoned()
    {
        string s = "The {pubescent} {medalion} was left in one of {Amadusos} {lesser} {temples}, in a truly desperate attempt to prevent the {curse}. It remains there to this day.";
        return s;
    }

    // All 'generate' below are incomplete.
    string generate_scorned()
    {
        return "You died old man!";
    }

    string generate_killed()
    {
        return "You died old man!";
    }

    string generate_stranded()
    {
        return "You died old man!";
    }

    string generate_lost()
    {
        return "You died old man!";
    }

    string generate_legends()
    {
        return "You died old man!";
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
