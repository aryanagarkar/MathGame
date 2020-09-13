// using System;
// using System.Collections.Generic;

// namespace service
// {
//     public class Link
//     {
//         int startNodeID;
//         int endNodeID;

//         String annotation;
//         bool activated;

//         public Link(int startNodeID, int endNodeID, AnnotationEnum annotation){
//             this.startNodeID = startNodeID;
//             this.endNodeID = endNodeID;
//             this.annotation = annotation.ToString();
//             activated = false;
//         }

//         public int StartNodeID{
//             get{return startNodeID; }
//         }

//         public int EndNodeID{
//             get{return endNodeID; }
//         }

//         public String Annotation{
//             get{return annotation.ToString(); }
//         }

//         public void activate(){
//             activated = true;
//         }

//         public void deactivate(){
//             activated = false;
//         }
//     }
// }
