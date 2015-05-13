using System;
using System.Collections.Generic;
using System.Text;

namespace ASFbuilder
{
    class Zubok
    {
        public const string DENIAL = "\nGorky Zubok. Colonel. " +   // Default answer when wisdom is exhausted
            "Niops Association Militia. Serial number 31415926";
        public List<string> Wisdom { get; set; }                    // List contains various replies
        public Random RNG { get; set; }                             // Random number generator
        public Zubok()
        {
            Wisdom = new List<string>();                            // Default constructor initializes list
            RNG = new Random();                                     // Initializes new RNG
            PopulateWisdom();                                       // Populates list
        }
        public void GetWisdom()                                     // Prints one of Zubok's pithy quotes
        {
            if (Wisdom.Count > 0)                                   // If list is not empty...
            {
                int next = RNG.Next(Wisdom.Count -1);               // Generate random number between 0 and size -1
                Console.WriteLine("\n===============================================================================");                                
                Console.WriteLine(Wisdom[next]);                    // Print string at that index and...
                Console.WriteLine("===============================================================================");
                Wisdom.RemoveAt(next);                              // Remove it to prevent duplication
            }
            else                                                    // If list is empty...
            {
                Console.WriteLine(DENIAL);                          // Give name, rank and serial number
                PopulateWisdom();                                   // Re-populate list
            }            
        }
        private void PopulateWisdom()                               // Adds replies to list
        {
            Wisdom.Add("For a force sterotyped as autocannon lovers, the AFFS sure has a lot of energy-heavy mech variants.");
            Wisdom.Add("A lampooned as they are for their love of assault mechs, the Lyrans have a lot of good lights and mediums.");
            Wisdom.Add("Aleksandr Kerensky is regarded as a general without equal, yet the Exodus was poorly planned, poorly supplied, " + 
                "and poorly lead. Once we discount planning, logistics, and organizational leadership, what qualtities of a great " +
                "general did Kerensky actually possess? \n\nI propose that like the Clans he spawned, the man was a tactical genius who " +
                "never transcended the role or maturity of a battlefield commander and never should have been promoted past major.");
            Wisdom.Add("Every interstellar organization is the product of people. We can deduce this by the fact that like people, " +
                "Successor States, Clans, and interstellar communications monopolies are usually their own worst enemies.");
            Wisdom.Add("What happens on Luxen stays on Luxen. I have the Cease & Desist order to prove it.");
            Wisdom.Add("The population of a single House capital or major world has a population six or seven times all of the Clans " +
                "combined. It's unfathomable to me that they are allowed to continue to exist unless the Lyran and Combine rulers " +
                "find the continued existance of their truculent neighbours to be convenient or their extermination to be a bloody " +
                "low priority. \n\nOf course, the Lyrans might just think the Falcons are better neighbours than the Dracs.");
            Wisdom.Add("I think we can agree that the Clan attitude that sexual relations are trivial minutiae and \"No big deal\" " +
                "and the fact that force is a socially acceptable method for individuals to assert their bonafides is really awkward.\n" +
                "\nThe fact that the Clan eugenics program lets trueborns keep all of their evolutionarily acquired sex drive and " +
                "reproductive capabilities intact only makes it worse.");
            Wisdom.Add("Clan trueborns keep full reproductive capabilties. I imagine that every female trueborn warrior must at some " +
                "point forcefully question the scientist caste why it was so vitally important for them to have periods when all of " +
                "Clan social engineering is designed to make reproduction an act of biological manufacturing fully divorced from the " +
                "daily concerns of most warriors.");
            Wisdom.Add("It never ceases to amaze me how volumous dropships are, and yet how cramped their interiors are always " +
                "described as being. You'd think they would put that space to good use. Dropship armour must have the density of " +
                "packing foam.");
            Wisdom.Add("Financially, self-employed mercenaries are completely inexplicable. Why fight and risk the destruction of " +
                "a valuable mech or fighter when its value when sold could make you rich for generations?\n\n The sophisticated mercenaries " +
                "of yesteryear did not bring their own heavy equipment. That was paid for, maintained, and insured by their employers. " +
                "Countries hired fighter pilots to fly fighters they had bought. A pilot able to own a fighter wouldn't need to work.");
            Wisdom.Add("It's astonishing how sturdy and how big building codes require buildings to be. Three meter-tall battle armour " +
                "weighing as much as a small car somehow fits through doorways sized for normal people. \n\nWere I designing bunkers to resist " +
                "attack by battle armour, my first course of action would be to specify low ceilings. You can't go where you can't fit.");
            Wisdom.Add("I think the secrets to sensible system designations were lost somewhere in the wilds of pre-spaceflight Terra.");
            Wisdom.Add("No, I don't know who Syrinx is.");
            Wisdom.Add("Once is happenstance, twice is coincidence, three times is SAFE in action because no one else is that sloppy.");
            Wisdom.Add("Optimism: A euphoric delusion usually brought about through the consumption of proscribed recreational " + 
                "pharmaceuticals. Naturally occurring in some instances of extreme information deprivation and fools.");
            Wisdom.Add("The heart of pragmatism is to stop asking \"What is right?\" and start asking \"What is effective?\"");
            Wisdom.Add("If you can justify a pre-emptive strike, you have pre-empted exactly nothing.");
            Wisdom.Add("Fairness is a transitory condition found in the dictionary and in life somewhere between \"failure\" and \"farce\"");
            Wisdom.Add("There is a misunderstanding about rough neighbourhoods, whether in the Periphery, Clan space, or the Chaos " + 
                "March. The quiet neighbours in rough neighbourhoods don't get a free pass by the riff-raff because they're nice. They " +
                "go about unmolested because everyone remembers what happened to the last lowlife to give them trouble.");
            Wisdom.Add("An occupied territory is an inhabited area under foreign administration where the populace have agreed that it " +
                "is better for the violent invaders to take what they want from the living than for them to take what is left from the " +
                "dead. Insurgents and rebels are those that dissent with this analysis.");
            Wisdom.Add("LAM (Land-Air Mechs) are bad mechs and worse fighters. Just looking at the concept, you can tell that they " +
                "are a successful compromise. No one got what they wanted and the product is bad at everything.");
            Wisdom.Add("Warship design exemplifies organizational schizophrenia. No one has the ships to conduct group operations but " +
                "everyone keeps designing ships meant to operate in a task force instead of independently. Maybe they're still leary " +
                "about independent cruising from the Exodus");
            Wisdom.Add("Armoured Personnel Carrier: A mobile box that may use hover, wheeled or tracked motive systems. They serve " +
                "as a spartan form of group transportation in peacetime and a self-propelled communal coffin in war");
            Wisdom.Add("One of the biggest breakthroughs in engineering has been the reduction in fuel mass required. Seagoing " + 
                "vessels and armoured fighting vehicles had to devote significant volume to fuel, while 20th and 21st century " + 
                "conventional aircraft frequently carried a third of their mass in fuel. \n\nA modern heavy or medium aerospace " + 
                "fighter usually devotes less than 10 percent.");
            Wisdom.Add("Attack helicopters are combat vehicles created by attaching deadly weapons to the most fragile type of " +
                "flying machines in the hopes that the difficulty of hitting them extends their battlefield lifespan enough to " +
                "allow the delivery of disproportionate damage before they are eradicated by proportionate return fire.");
            Wisdom.Add("Experience is the life-long process of learning when and where it is safe to cut corners and when and " +
                "where it is not. It's important to have the right experiences in the right order or else the \'life-long\' " +
                "may turn out to be rather abbreviated.");
            Wisdom.Add("Pessimists are people who expect the worst outcome imaginable. As knowing is half the battle, they " + 
                "are better prepared than the non-pessimist by exactly half.");
            Wisdom.Add("Optimists and pessimists both die equally badly. The optimist dies having been happy. The pessimist " +
                "dies having been right. You should pick which one you are by deciding whether you value truth or delusion.");
            Wisdom.Add("Knowing is half the battle. The other half is firepower.");
            Wisdom.Add("Here are some of the most frustratingly useless things: vehicles without fuel, weapons without ammo, " +
                "groups without leaders, and armies without orders. And they are probably all Comstar's fault.");
            Wisdom.Add("Reports and papers are like a drug den. Bullshit in front, good stuff in back. Whatever you're looking " +
                "for is in the appendix, hiding behind the qualifiers and evasive doublespeak.");
            Wisdom.Add("People ask if it's hard to kill a person as if all people are alike, but it's a question that deserves thought." +
                "\n\nFor one thing, the physical act can be quite difficult because the person you're trying to kill is usually " +
                "trying pretty hard to foil your attempt on their life.\n\nMorally, it really depends on which person in particular " + 
                "we're talking about. Some are considerate enough to solve any moral quandries for you ahead of time.");
            Wisdom.Add("Human organizations are gnarly, unwieldy beasts with a life of their own. Too often derided as simply " +
                "bureaucracy and dismissed as something immutable. Organizations are living things, their souls bound up in their " +
                "culture and conventions more than any vague mission statement or emblem. They are led and often badly, but the " +
                "greatest mistake is for their so-called leaders to think that they will have no effect. Few things are worse " +
                "for the whole than to have leaders that regard themselves as inconsequential.");
            Wisdom.Add("Rote and routine are often criticized, but it is only because certain things can be relied on that we " +
                "can focus all of our attentions on other matters undistracted.");
            Wisdom.Add("A pre-emptive strike is where you shoot people today that might otherwise shoot you tomorrow. " +
                "(Probably because you tried to shoot them today)");
            Wisdom.Add("Drones were invented the first time a pilot bailed out of an aircraft that proceeded to land itself. " +
                "Everything after that just involved figuring out how to get the aircraft to do more things without the pilot.");
            Wisdom.Add("3rdCrucisLancers once said: \"The Inner Sphere has a population of trillions. There's plenty of meat " + 
                "for the guns.\" All good and well if you're the Inner Sphere, but here in Niops, we have to be a bit more " +
                "resourceful than that.");
            Wisdom.Add("It was once a truism that generals are always preparing for the last war, but we have reached the point " +
                "where they no longer prepare for any wars, even as they continue to have them. How else to explain centuries " +
                "of war that consistently conclude in some sort of grotesque divinely-ordained stalemate?");
            Wisdom.Add("In my experience, humans are supremely adaptable. ONCE. Turning a mild-mannered accountant into a bloody-" +
                "minded infanteer or a polite county lawyer into a ruthless partisan is easier than you might expect. History " +
                "testifies that turning a war-zone refugee or violent genocidal war criminal into a respected pillar of the " + 
                " community is almost routine. People adapt, they make a new life, they become their new personas. It's when " +
                "you try to change them back that their minds really creak under the strain of their conflicting identies.");
            Wisdom.Add("Failure is always an option. Not only that, but in most cases it is also the default option.");
            Wisdom.Add("\"The sky is the limit\" is a terrible idiom in a society capable of spaceflight.");
            Wisdom.Add("The trite motivational quote that one should \"Shoot for the moon. Even if you miss, you'll land among " +
                "the stars.\" shows a stunning ignorance of basic astronomy and the nature of space.");
            Wisdom.Add("All failures are ultimately failures of leadership. Lack of resources and excess of scope are the same " +
                "thing and stem from poor planning. Underperforming subordinates are either poorly utilized, prepared, or " +
                "motivated. The leader bears responsibility for putting subordeinates in position to succeed or fail.");
            Wisdom.Add("I love classics as much as anyone else, but once in a while it would be nice to get some new material.");
            Wisdom.Add("The Director's private residences shall remain off-limits to the Transhumanist Inspectors. We possess " +
                "no consciousness-cloning capability, we are not researching sentient artificial intelligence, and we shall not " +
                "allow this intrusion on our rights as a sovereign entity in the name of this ridiculous witch hunt!");
        }
    }
}