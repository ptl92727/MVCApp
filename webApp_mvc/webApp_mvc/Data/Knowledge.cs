namespace webApp_mvc.Data
{
  public class Knowledge
  {
      public int Knowledge_Id { get; set; }
      public string Knowledge_Type { get; set; }
      public string Description { get; set;}

    public List<KnowledgeType> Knowledge { get; set; } = new();
  }
}
