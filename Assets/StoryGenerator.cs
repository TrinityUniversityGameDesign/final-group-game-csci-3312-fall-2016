using UnityEngine;
using System.Collections;

public class StoryGenerator : MonoBehaviour {

    class MainCharacter
    {
        public string adjective;
        public string occupation;
        public string name;
        public string history;
        public string his;
        public string he;
        public string him;
        public string servant;
        public string hobby;
        public MainCharacter(string adj, string occ, string nm, string hist, string his_t,
                             string he_t, string him_t, string servant_t, string hobby_t)
        {
            adjective = adj;
            occupation = occ;
            name = nm;
            history = hist;
            his = his_t;
            he = he_t;
            him = him_t;
            servant = servant_t;
            hobby = hobby_t;
        }
    } 

    class Relic
    {
        public string adjective;
        public string item;
        public string owner;
        public string curse;
        public string cursed;
        public string c1;
        public string c2;
        public string c3;
        public string cf;
        public string minions;
        public string val;
        public Relic(string adj, string it, string own, string curse_t, string cursed_t, string c1_t, string c2_t, string c3_t, 
                     string c4_t, string minions_t, string val_t)
        {
            adjective = adj;
            item = it;
            owner = own;
            curse = curse_t;
            cursed = cursed_t;
            c1 = c1_t;
            c2 = c2_t;
            c3 = c3_t;
            cf = cf_t;
            minions = minions_t;
            val = val_t;
        }
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
    */     

    // Eventually need to move out of here into a file as a template (do I?).
    // The things in {} can be swapped out for similar words. 
    // When making it, have it so corresponding words still appear, etc.
    string generate_opening(MainCharacter mc, Relic rel)
    {

        string s = "The great " + mc.adjective + " " + mc.occupation + " " +  mc.name +  " was noted for discovering the " + mc.history;
        s += " However, " + mc.his + " forgotten discovery was the discovery of the" +  rel.adjective + " " + rel.item +  " of " + rel.owner + ". ";
        s += "This is not the tale of that discovery, but of what befell " + mc.him + " after... ";
        return s;
    }

    string generate_cursed(MainCharacter mc, Relic rel)
    {
        string s = "However, there were {terrible} tales told of that " + rel.adjective + " " +  rel.item + ". Tales of a {horrible}" + rel.curse + ", which befalls any who are near that `";
        s +=  rel.adjective + " item.";
        s += "The stories told of being " + rel.c1 + " and being " +  rel.c2 + ", and several spoke of being " + rel.c3 + " you. ";
        s += "It did not initially inflict " + mc.name + " , it instead hit " + mc.his + " trusty " + mc.servant + ", who was tragically " + rel.c3 + ". ";
        s += mc.him + "." + " Leaving " + mc.name + " devastated. The " + rel.curse + " ravaged the crew, until only the " + mc.adjective + " " + mc.occupation + " " + mc.name + " was left alone. ";
        return s;
    }


    string generate_old(MainCharacter mc, Relic rel) {
    
        string s = "Realizing the gravity of " + mc.his + " doom, the " + mc.adjective + " " + mc.occupation + " abandoned the " + rel.item + ".";
        s += mc.name + " {prayed} that whatever {demonic} {gods} which " + rel.cursed + " "  + rel.owner + "'s " rel.item;
        s += rel.item + ". The " + mc.occupation + " abandoned the " + rel.item + ", and returned home. " + "Where " +  mc.he + " died of old age, many years later.";

        return s;
    }

    string generate_horrible(MainCharacter mc, Relic rel)
    {
        string s = "Tragically, like it was too late for the crew, it was too late for that " + mc.adjective + " " +  mc.name + " , even after " + mc.he + " had abandoned the" + rel.item + ". ";
        s += "The famous " + mc.occupation + " was " + rel.cursed + " by a fate more horrible than any of the fates spoken of in the tales.";
        s += mc.name + " was " + rel.cf + " by " + rel.minions + " of " + rel.owner + " " +  rel.him + "self. ";
        return s;
    }

    string generate_abandoned(Relic rel)
    {
        string s = "The " + rel.adjective + " " + rel.item + " was left in {the title of the game}, in a truly desperate attempt to prevent the " +  rel.curse + ". It remains there to this day. ";
        return s;
    }


    string generate_scorned(MainCharacter mc, Relic rel)
    {
        string s = "The " + rel.item + "  was valued at many " +  rel.val + " of dollars, enough for each of the large crew to live rich, for the rest of their lives." +  mc.name + " ";
        s += "was a cruel leader, causing the crew to dislike " + mc.him + " greatly. The crew felt scorned by the " + mc.adjective + " " + mc.occupation;
        s += ", who had always {beat them} {visciously}. They turned on " + mc.him + ".";
        s += "During " + mc.name + "'s daily " + mc.hobby + ", they surprised " + mc.him + ", {putting him in a hole in the ground}. They left to debate " +  mc.his + " fate. ";
        return s;
    }

    string generate_killed(MainCharacter mc, Relic rel)
    {
        string s = "Of all of the crew, only " + mc.his + " trusty " + mc.servant + " defended" +  mc.him + ", citing " + mc.his + " {generosity} despite how " + mc.he + "{beat them} {visciously}.";
        s += "Each of the crew came up with a terrible fate for the {explorer}. One suggested " + mc.he + " be {fed to wild dogs}. Another that " + mc.he + " be {decapitated}.";
        s += "Ultimately they settled that " + mc.he + " should be {buried alive beneath the sand}. Each crew member one by one spat on " + mc.him + " , as " + mc.he + " was ";
        s += "{ buried alive beneath the sand}. ";
        return s;
    }

    string generate_stranded(MainCharacter mc, Relic rel)
    {
        string s = "The crew pondered " +  mc.his + " fate. " + mc.name + "'s long trusted " +  mc.name + " argued passionately that " + mc.he + " be killed, citing years of abuse. The others ";
        s += "had only seen the kind side of the " + mc.occupation + ", and noted that, though {harsh}, was always {fair}. They decided that although " + mc.name + " did not deserve the treasure which ";
        s += "they had worked so hard to discover, + " + mc.he + " did not deserve death. Ultimately, the crew left" + mc.him + " behind, {on} a {deserted island}. ";
        s += "As a final show of hatred,  " + mc.name + "'s trusted ";
        s += mc.servant +  " {spat} on " +  mc.him + ". " + mc.name + " was never seen again.";
        return s;
    }
    string generate_lost(MainCharacter mc, Relic rel)
    {
        string s = "Much like how the crew turned on " +  mc.name  + ", they turned on each other. " +  mc.name + "'s trusted " + mc.servant + " was the first of the crew to be killed by";
        s += " the others. Each crew died one by one, as they each betrayed eachother. The final crew member {starved} to death. The " +  mc.item + " was lost in the ";
        s += rel.location + " near";
        s += " the {Title of the Game}. It was eventually taken to the {title of the game}.";
        return s;
    }

    string build_history()
    {
        return "staff of Alluhaasds at the great temple of Ushjdi";
    }

    string build_servant()
    {
        return "man-bear servant";
    }

    MainCharacter build_main_character()
    {
        // The history needs to be autogenerated too.
        return new MainCharacter("absurdist", "explorer", "Schwifty Von Amrack", build_history(), "his",
                                 "he", "him", build_servant(), "chess session");

    }

    Relic build_relic()
    {
        return new Relic("pubescent", "medalion", "Amaduso", "hex");

    }

    string[] make_story()
    {
        string[] story_pieces = new string[4];
        MainCharacter mc = build_main_character();
        story_pieces[0] = generate_opening(mc);
        bool cursed = false;
        if (cursed)
        {
            story_pieces[1] = generate_cursed(mc);
            bool old = false;
            if (old)
            {
                story_pieces[2] = generate_old(mc);
            } else
            {
                story_pieces[2] = generate_horrible(mc);
            }
            story_pieces[3] = generate_abandoned();
        } else
        {
            story_pieces[1] = generate_scorned(mc);
            bool killed = false;
            if (killed)
            {
                story_pieces[2] = generate_killed(mc);
            }
            else
            {
                story_pieces[2] = generate_stranded(mc);
            }
            story_pieces[3] = generate_lost(mc);
        }
        return story_pieces;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
