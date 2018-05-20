using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaApi.StravaModel.Activities
{
    public class DetailedActivity : Activity
    {
        public string description { get; set; }
        public float kilocalories { get; set; }        //uses kilojoules for rides and speed/pace for runs calories 
        public object gear { get; set; }                   //gear summary 
        public List<object> segment_efforts { get; set; } //array of summaryrepresentations of the segment efforts, segment effort ids must be represented as 64-bit datatypes    
        public List<object> splits_metric { get; set; } //array of metric split summaries running activities only
        public List<object> splits_standard { get; set; } //array of standard split summaries running activities only
        public List<object> laps { get; set; } //array of lap summaries  
        public List<object> best_efforts { get; set; } //array of best effort summaries running activities only
        public string device_name { get; set; }     //the name of the device used to record the activity.
        public string embed_token { get; set; }     //the token used to embed a Strava activity in the form www.strava.com/activities/[activity_id]/embed/[embed_token].	
        public object photos { get; set; }            //photos summary
    }

    public class SummaryActivity : Activity
    {

    }

    public abstract class Activity: StravaModelItem
    {
        public override string ApiDocumentUrl => "http://strava.github.io/api/v3/activities/";
        public int id { get; set; }
        public int resource_state { get; set; }     //indicates level of detail resource_state
        public string external_id { get; set; }     //provided at upload external_id
        public int upload_id {get;set;}
        public object athlete {get;set; }           //meta or summary 
        public string name {get;set;}
        public float distance { get; set; }         //meters 
        public int moving_time { get; set; }        //seconds 
        public int elapsed_time { get; set; }       //seconds 
        public float total_elevation_gain { get; set; }    //meters 
        public float elev_high { get; set; }        //meters 
        public float elev_low { get; set; }         //meters 
        public string type {get;set;}               //activity type, ie.ride, run, swim, etc.type 
        public string start_date {get;set;}         //time string
        public string start_date_local {get;set;}   //time string
        public string timezone {get;set;}
        public string start_latlng {get;set;}       //[latitude, longitude]
        public string end_latlng {get;set;}         //[latitude, longitude]
        public int achievement_count {get;set;}
        public int kudos_count {get;set;}
        public int comment_count {get;set;}
        public int athlete_count { get; set; }      //number of athletes taking part in this “group activity”. >= 1	
        public int photo_count { get; set; }        //number of Instagram photos 
        public int total_photo_count { get; set; }  //total number of photos(Instagram and Strava)   
        
        public object map { get; set; }             //detailed representation of the route    
        public bool trainer {get;set;}
        public bool commute {get;set;}
        public bool manual {get;set;}
        public bool isprivate {get;set;}            //property name is "private"
        public bool flagged {get;set;}
        public int workout_type { get; set; }       //for runs: 0 -> ‘default’, 1 -> ‘race’, 2 -> ‘long run’, 3 -> ‘workout’; for rides: 10 -> ‘default’, 11 -> ‘race’, 12 -> ‘workout’
        public string gear_id { get; set; }         //corresponds to a bike or pair of shoes included in athlete details 
        public float average_speed { get; set; }           //meters per second  
        public float max_speed { get; set; }               //meters per second  
        public float average_cadence { get; set; }         //RPM, if provided at upload 
        public float average_temp { get; set; }            //degrees Celsius, if provided at upload 
        public float average_watts { get; set; }           //rides only 
        public int max_watts {get;set; }            //rides with power meter data only 
        public int weighted_average_watts { get; set; } //rides with power meter data only similar to xPower or Normalized Power 
        public float kilojoules { get; set; }                  //rides only uses estimated power if necessary 
        public bool device_watts { get; set; }          //true if the watts are from a power meter, false if estimated 
        public bool has_heartrate { get; set; }         //true if recorded with heartrate 
        public float average_heartrate {get;set;}      //only if recorded with heartrate average over moving portion
        public int max_heartrate {get;set; }     //only if recorded with heartrate 
        
        public int suffer_score { get; set; }   //a measure of heartrate intensity, available on premium users’ activities only   
        public bool has_kudoed { get; set; }    //if the authenticated athlete has kudoed this activity 
      
      

    }
    }
