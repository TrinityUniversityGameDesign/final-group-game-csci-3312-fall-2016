using UnityEngine;
using System.Collections;

public class Question
{
    public string question;
    public string answer;
    public string[] choices;
}

public class StorySet
{
    public string[] title;
    public string story_1;
    public string story_2;
    public string story_3;
    public string story_4;
    public string artifact;
    public Question question_1;
    public Question question_2;
    public Question question_3;
    public Question question_4;
}

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

    string generate_abandoned(MainCharacter mc, Relic rel, string minions, string god, string title)
    {
        string s = "The " + rel.adjective + " " + rel.item + " was left in " + title + ", in a truly desperate attempt to prevent the " + rel.curse + ". ";
        s += "It is watched over by the " + minions + " of " + god;
        s += ". It remains there to this day. ";
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
    string generate_lost(MainCharacter mc, Relic rel, string title)
    {
        string s = "Much like how the crew turned on " +  mc.name  + ", they turned on each other. " +  mc.name + "'s trusted " + mc.servant + " was the first of the crew to be killed by";
        s += " the others. Each crew died one by one, as they each betrayed each other. The final crew member starved to death, alone. The " +  rel.item + " was lost in the ";
        s += rel.location + " near";
        s += " the " + title + ". It was eventually taken to the " +  title + ".";
        return s;
    }

    string build_history(string[] items, string[] gods, string[] locations)
    {
        string item = get_random(items) as string;
        string god = get_random(gods) as string;
        string location = get_random(locations) as string;
        return  item + " of " + god + " at the " + location;
    }



    object get_random(object[] elems)
    {
        return elems[Random.Range(0, elems.Length)];
    }

    MainCharacter build_main_character(string[] adjectives, string[] occupations, string[][] names, string[] servants, string[] items, string[] gods, string[] locations,
                                       string[] hobbies)
    {
        // The history needs to be autogenerated too.
        string[] name = get_random(names) as string[];
        return new MainCharacter(get_random(adjectives) as string, get_random(occupations) as string, name[0],
                                 build_history(items, gods, locations), name[1],
                                 name[2], name[3], get_random(servants) as string, get_random(hobbies) as string, "beat them visciously");

    }

    Relic build_relic(string[] adjectives, string[] items, string[] gods, string[] curses, string[] minions, string[] values, 
                      string[] locations)
    {
        
        return new Relic(get_random(adjectives) as string, get_random(items) as string, get_random(gods) as string, 
                         "hex", "hexed", get_random(curses) as string, get_random(curses) as string,
                         get_random(curses) as string, get_random(curses) as string, get_random(minions) as string,
                         get_random(values) as string, get_random(locations) as string);

    }

    GodReq build_god_req(string[] adjectives, string[] gods) {
        return new GodReq("prayed", get_random(adjectives) as string, get_random(gods) as string);
    }

    bool get_bool()
    {
        Debug.Log(Random.value);
        return Random.value > 0.5;
    }

    bool duplicates(string[] check)
    {
        for (int i = 0;i < check.Length;++i)
        {
            for (int j = i + 1;j < check.Length;++j)
            {
                if (check[i] == check[j]) return true;
            }
        }
        return false;
    }

    string[] shuffle(string[] answers)
    {

        int i = 0;
        while (i < 10)
        {
            int f = Random.Range(0, 4);
            string ft = answers[f];
            int s = Random.Range(0, 4);
            answers[f] = answers[s];
            answers[s] = ft;
            i += 1;
        }
        return answers;
    }

    Question build_question_and_answers(string question, string required, string[] options)
    {
        string[] ans = { required, "", "", "" };
        int i = 0;
        while (duplicates(ans))
        {
            ans[1] = get_random(options) as string;
            ans[2] = get_random(options) as string;
            ans[3] = get_random(options) as string;
            i += 1;
            if (i > 1000) break;
        }
        ans = shuffle(ans);
        Question ret = new Question();
        ret.question = question;
        ret.answer = required;
        ret.choices = ans;
        return ret;
    } 

    string[] make_title()
    {
        string[] hiddens_op = { "Hidden", "Mysterious", "Obscure", "Magnificent", "Unseen", "Invisible", "Forgotten"};

        string[] legends_op = { "Legends" , "Myths", "Tales", "Sagas", "Fables"};
        string[] temple_op = {"Shrine", "Mosque", "Church", "Castle", "Palace", "Temple"};
        string legends = get_random(legends_op) as string;
        string hidden = get_random(hiddens_op) as string;
        string temple = get_random(temple_op) as string;
        while (legends == "legends" && hidden == "hidden" && temple == "temple")
        {
            legends = get_random(legends_op) as string;
            hidden = get_random(hiddens_op) as string;
            temple = get_random(temple_op) as string;
        }
        string ret_1 = legends + " of the";
        string ret_2 = hidden + " " + temple;
        string[] ret = { ret_1, ret_2};
        return ret;
    }

    StorySet make_story()
    {
        StorySet story = new StorySet();
        story.title = make_title();
        // These are the various options for all of the things.
        string[] adjectives = {"pubescent", "omnivorous", "vegetarian", "aloof", "forgetful", "absurd",
                               "carnivorous", "powerful", "frightening", "religious", "sweaty", "demonic", "first",
                               "second", "10,000 year old", "fourty third", "prime" , "hungry"};
 
        string[] occupations = { "explorer", "author", "king", "general", "inventor", "explorer", "professor", "president", "plantation owner",
                                 "researcher", "computer"};

        // options for the names of the main character.
        string[] names_one = { "Schwifty Von Amrack", "his", "he", "him" };
        string[] names_two = { "Indiana Jones", "his", "he", "him" };
        string[] names_thr = { "Amelia Earhart", "her", "she", "her" };
        string[] names_fou = { "Ada Lovelace", "her", "she", "her"};
        string[] names_fiv = { "Arsene Cagliostro", "his", "he", "him" };
        string[] names_six = { "Michelle Obama", "her", "she", "her" };
        string[] names_sev = { "Matthew Hibbs", "his", "he", "him" };
        string[] names_eig = { "Hilary Clinton", "her", "she", "her" };
        string[] names_nin = { "Jesus Christ", "his", "he", "him" };
        string[] names_ten = { "Kazi Azrul", "her", "she", "her" };
        string[] names_non_object = { "HAL 9000", "its", "it", "it" };

        string[][] names = { names_one, names_two, names_thr, names_fou, names_fiv, names_six,
                             names_sev, names_eig, names_nin, names_ten, names_non_object };
        string[] items = { "medallion", "staff", "statute", "ark", "scepter", "sword", "necklace" };
        string[] gods = { "Amadeus", "Amaduso", "God", "Shiba", "Shiba Uno", "Pan", "Balphegor", "Hitler"};
        string[] curses = { "burned alive", "crippled", "mummified",
                            "stoned", "calcified", "poked", "put to sleep", "drowned", "befuddled", "staked", "killed", "abandoned",
                            "forgotten", "cleaned", "absorbed", "swallowed", "pacified", "breast fed by a huge angry god"};
        string[] minions = { "minions", "priests", "servants", "zombies", "secret police", "foot-soliders", "altar boys", "vampires", "nazis"};
        string[] values = { "millions", "thousands", "tens", "billions", "trillions", "oodles", "piles", "baker's dozens" };
        string[] locations = {"great desert of mushu", "terrible islands of the Skitz", "magnificent puddles of Elusis",
                              "temple of Apollo", "grave of Jesus", "grave of Isaac Newton", "one bar in Wyoming with good liquor",
                              "grave of " + get_random(gods) as string, "grave of " + get_random(gods) as string, "grave of " + get_random(gods) as string,
                              "temple of " + get_random(gods) as string, "temple of " + get_random(gods) as string, "statute to " + get_random(gods) as string};
        string[] servants = { "man-bear servant", "shark-headed assistant", "long-nosed manservant", "large headed maid", "submarine the Constitution", "demon" };
        string[] god_types = { "gods", "devils", "eldtrich horrors" };

        string[] hobbies = { "chess session", "running session", "yoga class", "me time", "underwater basket weaving session"};

        string[] deaths = { "burned alive", "fed to wild dogs", "buried alive in hot, acidic sand", "eaten", "curb stomped", "decapitated","drowned",
                            "beaten to the music of Mozart", "sacrificed to the great god " + get_random(gods) as string,
                            "sacrificed to the great god " + get_random(gods) as string, "slaughtered for the great god " + get_random(gods) as string,
                            "murder for the great god " + get_random(gods) as string, "mummified for the great god " + get_random(gods) as string,
                            "fed to some random " + get_random(minions) as string, "beaten by some random " + get_random(minions) as string,
                            "eaten by some random " + get_random(minions) as string};
        string[] abandoned = {"on a deserted island", "inside a large volcano", "on top a huge mountain", "inside of a pyramid", "in the middle of the desert",
                              "near " + get_random(locations) as string, "near " + get_random(locations) as string, "near " + get_random(locations) as string};
        // Thus ends the options
        string[] story_pieces = new string[4];
        string[][] questions = new string[5][];
        MainCharacter mc = build_main_character(adjectives, occupations, names, servants, items, gods, locations, hobbies);
        GodReq god_req = build_god_req(adjectives, god_types);
        Relic rel = build_relic(adjectives, items, gods, curses, minions, values, locations);
        story.artifact = rel.item;
        story.story_1 = generate_opening(mc, rel);
        // Questions and answers possibilities for the first question.
        Question[] questions_opening = {build_question_and_answers("What adjective would you use to describe " + mc.name + "?", mc.adjective, adjectives),
                                   build_question_and_answers("What did " +  mc.he + " discover?", rel.item, items),
                                   build_question_and_answers("What adjective would you use to describe the " + rel.item + "?", rel.adjective, adjectives)};
        story.question_1 = get_random(questions_opening) as Question;
        if (get_bool())
        {
            story.story_2 = generate_cursed(mc, rel);
            Question[] questions_cursed = {build_question_and_answers("How was the " + mc.servant + " cursed?", rel.c3, curses),
                                   build_question_and_answers("Who was most trusted by " +  mc.name + " ?", mc.servant, servants)};
            story.question_2 =  get_random(questions_cursed) as Question;
            if (get_bool())
            {

                Question[] questions_old = {build_question_and_answers("What kind of " + god_req.gods + " did " + mc.name + " pray to?", god_req.adj, adjectives),
                                   build_question_and_answers("What did " +  mc.he + " pray to?", god_req.gods, god_types),};
                story.question_3 = get_random(questions_old) as Question;
                story.story_3 = generate_old(mc, rel, god_req);
            } else
            {

                Question[] questions_horrible = {build_question_and_answers("What killed " + mc.name + "?", rel.minions , minions),
                                   build_question_and_answers("How did " + mc.name + " die?", rel.cf, curses)};
                story.question_3 = get_random(questions_horrible) as Question;
                story.story_3 = generate_horrible(mc, rel);
            }
            // NEED TO MAKE QUESTION FOR ABANDONED.
            string minion = get_random(minions) as string;
            string god = get_random(gods) as string;
            Question[] questions_abandoned = {build_question_and_answers("What were the servants of " + god + "?", minion, minions),
                                   build_question_and_answers("Who is in charge of the " +  minion + "?", god, gods)};
            story.question_4 = get_random(questions_abandoned) as Question;

            story.story_4 = generate_abandoned(mc, rel, minion, god, story.title[1]);
        } else
        {

            //
            // Putting him in a hole in the ground should be replaced with something. 
            //
            story.story_2 = generate_scorned(mc, rel, "putting him in a hole in the ground");
            Question[] questions_scorned = {build_question_and_answers("What hobby does " + mc.name + " have?", mc.hobby, hobbies),
                                   build_question_and_answers("How much money does the " +  rel.item + " cost?", rel.val, values)};
            story.question_2 = get_random(questions_scorned) as Question;
            if (get_bool())
            {

                string first = get_random(deaths) as string;
                string second = get_random(deaths) as string;
                int i = 0;
                while (second == first )
                {
                    second = get_random(deaths) as string;
                    i += 1;
                    if (i > 1000) break;
                }
                string third = get_random(deaths) as string;
                i = 0;
                while (third == second || third == first)
                {
                    third = get_random(deaths) as string;
                    i += 1;
                    if (i > 1000) break;
                }
                story.story_3 = generate_killed(mc, rel, first, second, third);
                Question[] questions_killed = {build_question_and_answers("Who was most trusted by " +  mc.name + " ?", mc.servant, servants),
                                               build_question_and_answers("What fate did " +  mc.name + " suffer?", third, deaths),
                                               build_question_and_answers("What fate was suggested first?", first, deaths),
                                               build_question_and_answers("What fate was suggested second?", second, deaths)};
                story.question_3 = get_random(questions_killed) as Question;
            }
            else
            {
                string loc = get_random(abandoned) as string;
                story.story_3 = generate_stranded(mc, rel, loc);
                Question[] questions_stranded = { build_question_and_answers("Where was " + mc.name + " left behind?", loc, abandoned) };
                story.question_3 = get_random(questions_stranded) as Question;
            }
            story.story_4 = generate_lost(mc, rel, story.title[1]);
            Question[] questions_lost = {build_question_and_answers("Where was the " + rel.item + " lost?", rel.location, locations),
                                         build_question_and_answers("Where was the " + rel.item + "of " + rel.owner + " lost?", rel.location, locations)};
            story.question_4 = get_random(questions_lost) as Question;
        }
        return story;
    }

    public StorySet story;
    // Use this for initialization
    void Start () {
    }
	
    public StorySet generate_story()
    {
        Random.seed = PlayerPrefs.GetInt("RandomSeedStory");
        return make_story();
    }

	// Update is called once per frame
	void Update () {
	    
	}
}
