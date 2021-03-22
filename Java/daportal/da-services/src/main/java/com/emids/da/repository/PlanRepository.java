package com.emids.da.repository;

import com.emids.da.model.MonthlyPlan;
import com.emids.da.repository.AbstractRepository;
import com.google.inject.persist.Transactional;

@Transactional
public class PlanRepository extends AbstractRepository<MonthlyPlan> {

  @Override
  public MonthlyPlan findById(Long id) {
    return find(MonthlyPlan.class, id);
  }
}
