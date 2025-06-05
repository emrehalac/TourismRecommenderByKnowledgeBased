using Microsoft.AspNetCore.Mvc;
using TourismRecommenderByKnowledgeBased.Models;
using TourismRecommenderByKnowledgeBased.Services;

namespace TourismRecommenderByKnowledgeBased.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly RuleEngineService _engine;
        private readonly GeminiService _gemini;

        public RecommendationController(RuleEngineService engine, GeminiService gemini)
        {
            _engine = engine;
            _gemini = gemini;
        }

        [HttpPost("submit_answers")]
        public async Task<IActionResult> SubmitAnswers([FromBody] UserPrefs prefs)
        {
            var destination = _engine.GetBestDestination(prefs);
            if (destination == null)
            {
                return NotFound();
            }

            var explanation = await _gemini.GetExplanationAsync(destination.Name);
            var result = new RecommendationResult
            {
                Destination = destination.Name,
                Explanation = explanation
            };
            return Ok(result);
        }
    }
}
