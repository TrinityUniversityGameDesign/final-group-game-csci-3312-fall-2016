﻿using UnityEngine;
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
        public string abuse;
        public MainCharacter(string adj, string occ, string nm, string hist, string his_t,
                             string he_t, string him_t, string servant_t, string hobby_t, string abuse_t)
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
            abuse = abuse_t;
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
        public string location;
        public Relic(string adj, string it, string own, string curse_t, string cursed_t, string c1_t, string c2_t, string c3_t, 
                     string cf_t, string minions_t, string val_t, string location_t)
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
            location = location_t;
        }
    }

    class GodReq {
        public string prayed;
        public string adj;
        public string gods;
        public GodReq(string pray_t, string adj_t, string god_t) {
            prayed = pray_t;
            adj = adj_t;
            gods = god_t;
        }
    }

    /* The branching story:
     * Advanture can lead to being: (generate_opening) COMPLETE
     *     cursed, which leads to: (generate_cursed). COMPLETE
     *         All the men die, you die of old age. (generate_old)
     *         Or, you die too, a horrible death somehow. (generate_horrible)
     *             In either case, the treasure is abandoned somewhere.Which leads to the end state. (generate_abandoned).
     *     scorned, all your crew turns on you. Which leads to: (generate_scorned)
     *         You are killed, and the treasure is taken. By your crew. (generate_killed)
     *         Or, they leave you stranded to die somehwere. (generate_stranded)
     *             In Either case, the crew utlimately kill each other, leaving the treasure somewhere along the route home. Which leads to the end state. (generate_lost).
    */     

    string generate_opening(MainCharacter mc, Relic rel)
    {

        string s = "The great " + mc.adjective + " " + mc.occupation + " " +  mc.name +  " was noted for discovering the " + mc.history;
        s += ". However, " + mc.his + " forgotten discovery was the discovery of the " +  rel.adjective + " " + rel.item +  " of " + rel.owner + ". ";
        s += "This is not the tale of that discovery, but of what befell " + mc.him + " after... ";
        return s;
    }

    string generate_cursed(MainCharacter mc, Relic rel)
    {
        string s = "However, there were tales told of that " + rel.adjective + " " +  rel.item + ". Tales of a horrible " + rel.curse + ", which befalls any who are near that ";
        s +=  rel.adjective + " item. ";
        s += "The stories told of being " + rel.c1 + " and being " +  rel.c2 + ", and several spoke of being " + rel.c3 + " .";
        s += "It did not initially inflict " + mc.name + ", it instead hit " + mc.his + " trusty " + mc.servant + ", who was tragically " + rel.c3;
        s +=  ", " + "leaving " + mc.name + " devastated. The " + rel.curse + " ravaged the crew, until only the " + mc.adjective + " " + mc.occupation + " " + mc.name + " was left alone. ";
        return s;
    }


    string generate_old(MainCharacter mc, Relic rel, GodReq god) {
        string s = "Realizing the gravity of " + mc.his + " doom, the " + mc.adjective + " " + mc.occupation + " abandoned the " + rel.item + ". ";
        s += mc.name + " " + god.prayed + " to whatever " +  god.adj + " " + god.gods + " which " + rel.cursed + " "  + rel.owner + "'s ";
        s += rel.item + ". The " + mc.occupation + " left behind the " + rel.item + ", and returned home, " + "where " +  mc.he + " died of old age, many years later.";

        return s;
    }

    string generate_horrible(MainCharacter mc, Relic rel)
    {
        string s = "Tragically, like it was too late for the crew, it was too late for that " + mc.adjective + " " +  mc.name + ", even after " + mc.he + " had abandoned the " + rel.item + ". ";
        s += "The famous " + mc.occupation + " was " + rel.cursed + " by a fate more horrible than any of the fates spoken of in the legends. ";
        s += mc.name + " was " + rel.cf + " by the " + rel.minions + " of " + rel.owner + ". ";
        return s;
    }

    string generate_abandoned(MainCharacter mc, Relic rel)
    {
        string s = "The " + rel.adjective + " " + rel.item + " was left in {the title of the game}, in a truly desperate attempt to prevent the " +  rel.curse + ". It remains there to this day. ";
        return s;
    }


    string generate_scorned(MainCharacter mc, Relic rel, string prison)
    {
        string s = "The " + rel.item + "  was valued at many " +  rel.val + " of dollars, enough for each of the large crew to live rich, for the rest of their lives. " +  mc.name + " ";
        s += "was a cruel leader, causing the crew to dislike " + mc.him + " greatly. The crew felt scorned by the " + mc.adjective + " " + mc.occupation;
        s += ", who had always " +  mc.abuse + ". They turned on " + mc.him + ". ";
        s += "During " + mc.name + "'s daily " + mc.hobby + ", they surprised " + mc.him + ", " + prison +". They left to debate " +  mc.his + " fate. ";
        return s;
    }

    string generate_killed(MainCharacter mc, Relic rel, string fate_1, string fate_2, string fate)
    {
        string s = "Of all of the crew, only " + mc.his + " trusty " + mc.servant + " defended " +  mc.him + ", citing " + mc.his + " generosity despite how " + mc.he + " " + mc.abuse + ". ";
        s += "Each of the crew came up with a terrible fate for the " + mc.occupation +". One suggested " + mc.he + " be " +  fate_1 + ". Another that " + mc.he + " be " + fate_2 + ". ";
        s += "Ultimately they settled that " + mc.he + " should be " +  fate + ". Each crew member one by one spat on " + mc.him + ", as " + mc.he + " was ";
        s +=  fate + ". ";
        return s;
    }

    string generate_stranded(MainCharacter mc, Relic rel, string abandoned)
    {
        string s = "The crew pondered " +  mc.his + " fate. " + mc.name + "'s long trusted " +  mc.name + " argued passionately that " + mc.he + " be killed, citing years of abuse. The others ";
        s += "had only seen the kind side (despite that that was totally false) of the " + mc.occupation + ", and noted that, though harsh, was always fair. They decided that although ";
        s += mc.name + " did not deserve the treasure which ";
        s += "they had worked so hard to discover, " + mc.he + " did not deserve death. Ultimately, the crew left " + mc.him + " behind, " + abandoned + ". ";
        s += "As a final show of hatred,  " + mc.name + "'s trusted ";
        s += mc.servant +  " spat on " +  mc.him + ". " + mc.name + " was never seen again.";
        return s;
    }
    string generate_lost(MainCharacter mc, Relic rel)
    {
        string s = "Much like how the crew turned on " +  mc.name  + ", they turned on each other. " +  mc.name + "'s trusted " + mc.servant + " was the first of the crew to be killed by";
        s += " the others. Each crew died one by one, as they each betrayed eachother. The final crew member starved to death, alone. The " +  rel.item + " was lost in the ";
        s += rel.location + " near";
        s += " the {Title of the Game}. It was eventually taken to the {title of the game}.";
        return s;
    }

    string build_history()
    {
        return "staff of Alluhaasds at the great temple of Ushjdi";
    }



    object get_random(object[] elems)
    {
        return elems[Random.Range(0, elems.Length)];
    }

    MainCharacter build_main_character(string[] adjectives, string[] occupations, string[][] names, string[] servants)
    {
        // The history needs to be autogenerated too.
        string[] name = get_random(names) as string[];
        return new MainCharacter(get_random(adjectives) as string, get_random(occupations) as string, name[0],
                                 build_history(), name[1],
                                 name[2], name[3], get_random(servants) as string, "chess session", "beat them visciously");

    }

    Relic build_relic(string[] adjectives, string[] items, string[] gods, string[] curses, string[] minions, string[] values, 
                      string[] locations)
    {
        
        return new Relic(get_random(adjectives) as string, get_random(items) as string, get_random(gods) as string, 
                         "hex", "hexed", get_random(curses) as string, get_random(curses) as string,
                         get_random(curses) as string, get_random(curses) as string, get_random(minions) as string,
                         get_random(values) as string, get_random(locations) as string);

    }

    GodReq build_god_req(string[] adjectives) {
        return new GodReq("prayed", get_random(adjectives) as string, "gods");
    }

    bool get_bool()
    {
        Debug.Log(Random.value);
        return Random.value > 0.5;
    }

    string[] make_story()
    {

        // These are the various options for all of the things.
        string[] adjectives = {"pubescent", "omnivorous", "vegetarian", "aloof", "forgetful", "absurd",
                               "carnivorous", "powerful", "frightening", "religious", "sweaty", "demonic"};
        string[] occupations = { "explorer", "author", "king", "general", "inventor", "explorer", "professor" };

        // options for the names of the main character.
        string[] names_one = { "Schwifty Von Amrack", "his", "he", "him" };
        string[] names_two = { "Indiana Jones", "his", "he", "him" };
        string[] names_thr = { "Amelia Earhart", "her", "she", "her" };
        string[] names_fou = { "Ada Lovelace", "her", "she", "her"};

        string[][] names = { names_one, names_two, names_thr, names_fou };
        string[] items = { "medalion", "staff", "statute", "ark", "scepter", "sword", "necklace" };
        string[] gods = { "Amadeus", "Amaduso", "God", "Shiba", "Shiba Uno", "Pan", "Balphegor", "Hitler"};
        string[] curses = { "burned alive", "crippled", "mummified",
                            "stoned", "calcified", "poked", "put to sleep", "drowned", "befuddled", "staked", "killed", "abandoned",
                            "forgotten", "cleaned", "absorbed", "swallowed", "pacified", "breast fed by a huge angry god"};
        string[] minions = { "minions", "priests", "servants", "zombies", "secret police", "foot-soliders", "altar boys", "vampires"};
        string[] values = { "millions", "thousands", "tens", "billions", "trillions", "oodles", "piles", "baker's dozens" };
        string[] locations = {"great desert of mushu", "terrible islands of the Skitz", "magnificent puddles of Elusis",
                              "the temple of Apollo", "the grave of Jesus", "the resting place of the great hero, Hercules,"};
        string[] servants = { "man-bear servant", "shark-headed assistant", "long-nosed manservant", "large headed maid", "submarine the Constitution" };

        // Thus ends the options
        string[] story_pieces = new string[4];
        string[] questions = new string[4];
        MainCharacter mc = build_main_character(adjectives, occupations, names, servants);
        GodReq god_req = build_god_req(adjectives);
        Relic rel = build_relic(adjectives, items, gods, curses, minions, values, locations);
        story_pieces[0] = generate_opening(mc, rel);
        if (get_bool())
        {
            story_pieces[1] = generate_cursed(mc, rel);
            if (get_bool())
            {
                story_pieces[2] = generate_old(mc, rel, god_req);
            } else
            {
                story_pieces[2] = generate_horrible(mc, rel);
            }
            story_pieces[3] = generate_abandoned(mc, rel);
        } else
        {
            story_pieces[1] = generate_scorned(mc, rel, "putting him in a hole in the ground");
            if (get_bool())
            {
                story_pieces[2] = generate_killed(mc, rel, "burned alive", "fed to wild dogs", "buried alive in hot, acidic sand");
            }
            else
            {
                story_pieces[2] = generate_stranded(mc, rel, "on a deserted island");
            }
            story_pieces[3] = generate_lost(mc, rel);
        }
        return story_pieces;
    }

    string[] story;
    // Use this for initialization
    void Start () {
        story = make_story();
        for (int i = 0;i < 4;++i)
        {
            Debug.Log(story[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
