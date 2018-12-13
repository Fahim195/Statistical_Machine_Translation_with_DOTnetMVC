using edu.stanford.nlp.tagger.maxent;
using SMT_MVCv2.Models.Approaches.DirectApproach;
using SMT_MVCv2.Models.Approaches.StatisticalTranslation;
using SMT_MVCv2.Models.Approaches.TransferApprach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMT_MVCv2.Models
{
    public class PoS_taggingPhase
    {
        string[] word;
        string[] POStag;
        public string postaggingAND_translation(string SourceLanguage, String ApproachName)
        {
            var jarRoot = @"C:\Users\fahim\source\repos\SMT_MVCv2\SMT_MVCv2\packages\stanford-postagger-full-2018-02-27\stanford-postagger-full-2018-02-27";
            var modelsDirectory = jarRoot + @"\models";

            // Loading POS Tagger
            var tagger = new MaxentTagger(modelsDirectory + @"\english-bidirectional-distsim.tagger");
            // Text for tagging           
            string[] words = SourceLanguage.Split(' ');
            word = new string[words.Length];
            POStag = new string[words.Length];
            string abc = "";
            string words_withPOStag= tagger.tagString(SourceLanguage);
            //string tagged = tagger.tagString(SourceLanguage);
            for (int i = 0; i < words.Length; i++)
            {
                string tagged = tagger.tagString(words[i]);     // Initializing Tag for  word
                string[] word_PosTag_split = tagged.Split('_'); // Splitting Word and POS Tag
                word[i] = word_PosTag_split[0];                 // Assinging word to array
                POStag[i] = word_PosTag_split[1];               // Assinging  POS Tag to array
                abc += POStag[i];
            }
            string sentence = "";
            if (ApproachName == "Transfer Approach")
            {
                Analysis_stg aaAnalysis_Stg = new Analysis_stg();
                sentence = aaAnalysis_Stg.getSubject(word, POStag);
            }
            else if (ApproachName == "Direct Approach")
            {
                Morphological_Analysis aMorphological_Analysis = new Morphological_Analysis();
                sentence = aMorphological_Analysis.StarMorphologicalAnalysis(word, POStag);
            }
            else if (ApproachName == "Statistical Translation")
            {
                ExtractTargetLanguage_Results aExtractTargetLanguage_Results = new ExtractTargetLanguage_Results();
                sentence = aExtractTargetLanguage_Results.getTargetSentences_According_to_Source(SourceLanguage);
            }
            //else if (ApproachName == "Interlingua Approach") { }

            //else if (ApproachName == "Corpus-based Approach") { }           
            return sentence;

        }
    }
}