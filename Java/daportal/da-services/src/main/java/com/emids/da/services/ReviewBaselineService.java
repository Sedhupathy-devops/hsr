package com.emids.da.services;

import com.emids.da.model.ReviewBaseline;

import java.util.List;

public interface ReviewBaselineService {
  /**
   * Retrieve list of projects whose rating are NON-GREEN based on IR Rating
   *
   * @param months months
   * @param years  year
   * @return list of reviews
   */
  List<ReviewBaseline> getNonGreenProjectsForQuarter(final String months, final String years);

  /**
   * Returns all projects that has any scores less than 60 and nternal rating as GREEN
   *
   * @param months months
   * @param years  years
   * @return list of projects
   */
  List<ReviewBaseline> getProjectsWithScoresBelowThreshold(final String months, final String years);
}
