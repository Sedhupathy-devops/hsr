package com.emids.da.repository;

import com.emids.da.commons.enumerations.Ratings;
import com.emids.da.model.ReviewBaseline;
import com.google.inject.persist.Transactional;

import java.util.List;

import static com.emids.da.model.QReviewBaseline.reviewBaseline;

@Transactional
public class ReviewBaselineRepository extends AbstractRepository<ReviewBaseline> {

  /**
   * Get the persisted instance with the given id
   *
   * @param id id to be searched
   * @return returns an Entity object
   */
  @Override
  public ReviewBaseline findById(Long id) {
    return find(ReviewBaseline.class, id);
  }

  /**
   * Retrieve list of projects whose rating are NON-GREEN based on IR Rating
   *
   * @param months months
   * @param years  year
   * @return list of projects
   */
  public List<ReviewBaseline> getNonGreenProjectsForQuarter(final String months, final String years) {

    return selectFrom(reviewBaseline)
      .where(reviewBaseline.internalRating.notEqualsIgnoreCase(Ratings.GREEN.getRatingCode())
        .and(reviewBaseline.month.in(months))
        .and(reviewBaseline.year.in(years)))
      .groupBy(reviewBaseline.accountName, reviewBaseline.projectName)
      .orderBy(reviewBaseline.accountName.asc())
      .fetch();
  }

  /**
   * Returns all projects that has any scores less than 60 and nternal rating as GREEN
   *
   * @param months months
   * @param years  years
   * @return list of projects
   */
  public List<ReviewBaseline> getProjectsWithScoresBelowThreshold(final String months, final String years) {

    return selectFrom(reviewBaseline)
      .where(reviewBaseline.internalRating.equalsIgnoreCase(Ratings.GREEN.getRatingCode())
        .and(reviewBaseline.month.in(months))
        .and(reviewBaseline.year.in(years))
        .and((reviewBaseline.emScore.gt(60).or(reviewBaseline.emScore.lt(0)))
          .or(reviewBaseline.qaScore.gt(60).or(reviewBaseline.qaScore.lt(0)))
          .or(reviewBaseline.tqScore.gt(60).or(reviewBaseline.tqScore.lt(0)))
          .or(reviewBaseline.baScore.gt(60).or(reviewBaseline.baScore.lt(0)))
          .or(reviewBaseline.biScore.gt(60).or(reviewBaseline.biScore.lt(0))))
      ).fetch();
  }
}
